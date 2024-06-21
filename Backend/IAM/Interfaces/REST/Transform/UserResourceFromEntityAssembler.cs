using Backend.IAM.Domain.Model.Aggregates;
using Backend.IAM.Interfaces.REST.Resources;

namespace Backend.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Email);
    }
}