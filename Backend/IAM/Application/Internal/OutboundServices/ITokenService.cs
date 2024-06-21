using Backend.IAM.Domain.Model.Aggregates;

namespace Backend.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);

    Task<int?> ValidateToken(string token);
}