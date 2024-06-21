using Backend.IAM.Domain.Model.Aggregates;
using Backend.IAM.Interfaces.REST.Resources;

namespace Backend.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Email, token);
    }
}