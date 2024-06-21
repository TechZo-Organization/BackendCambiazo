using Backend.IAM.Application.Internal.OutboundServices;
using Backend.IAM.Domain.Model.Queries;
using Backend.IAM.Domain.Services;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace Backend.IAM.Infrastructure.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestAuthorizationMiddleware> _logger;

    public RequestAuthorizationMiddleware(RequestDelegate next, ILogger<RequestAuthorizationMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(
        HttpContext context,
        IUserQueryService userQueryService,
        ITokenService tokenService)
    {
        _logger.LogInformation("Entering InvokeAsync");

        var endpoint = context.Request.HttpContext.GetEndpoint();
        if (endpoint == null)
        {
            _logger.LogInformation("No endpoint found, skipping authorization");
            await _next(context);
            return;
        }

        var allowAnonymous = endpoint.Metadata
            .Any(m => m.GetType() == typeof(AllowAnonymousAttribute));
        _logger.LogInformation($"Allow Anonymous is {allowAnonymous}");

        if (allowAnonymous)
        {
            _logger.LogInformation("Skipping authorization");
            await _next(context);
            return;
        }

        _logger.LogInformation("Entering authorization");

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (token == null)
        {
            _logger.LogWarning("Token is null");
            throw new Exception("Null or invalid token");
        }

        var userId = await tokenService.ValidateToken(token);
        if (userId == null)
        {
            _logger.LogWarning("Token is invalid");
            throw new Exception("Invalid token");
        }

        var getUserByIdQuery = new GetUserByIdQuery(userId.Value);
        var user = await userQueryService.Handle(getUserByIdQuery);

        _logger.LogInformation("Successful authorization. Updating Context...");
        context.Items["User"] = user;

        _logger.LogInformation("Continuing with Middleware Pipeline");
        await _next(context);
    }
}