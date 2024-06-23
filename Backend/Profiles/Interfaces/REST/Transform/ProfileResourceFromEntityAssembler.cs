using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Interfaces.REST.Resources;

namespace Backend.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.FullName, entity.EmailAddress, entity.PhoneNumber,
            entity.ProfilePhoto, entity.MembershipId);
    }
}