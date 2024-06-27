using System.Net.Mime;
using Backend.IAM.Domain.Model.Commands;
using Backend.IAM.Domain.Model.Queries;
using Backend.IAM.Domain.Services;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Backend.IAM.Interfaces.REST.Resources;
using Backend.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController(IUserQueryService userQueryService,IUserCommandService userCommandService) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var user = await userQueryService.Handle(getUserByIdQuery);
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user!);
        return Ok(userResource);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
    
    [AllowAnonymous]
    //put
    [HttpPut("{userId:int}")]
    public async Task<IActionResult> UpdateUser(int userId, SignUpResource sign)
    {
        var updateUserCommand = new UpdateUserCommand(userId, sign.Email, sign.Password);
        var user = await userCommandService.Handle(updateUserCommand);
        if (user == null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }
    
    [AllowAnonymous]
    //delete
    [HttpDelete("{userId:int}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var deleteUserCommand = new DeleteUserCommand(userId);
        var user = await userCommandService.Handle(deleteUserCommand);
        if (user == null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }
    
}