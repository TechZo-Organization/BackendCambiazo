using Backend.Profiles.Domain.Model.Entities;
using Backend.Profiles.Interfaces.REST.Resources;

namespace Backend.Profiles.Interfaces.REST.Transform;

public class MembershipResourceFromEntityAssembler
{
    public static MembershipResource ToResourceFromEntity(Membership entity)
    {
        return new MembershipResource(entity.Id, entity.Name, entity.Description, entity.Price, entity.Benefits);
    }
}