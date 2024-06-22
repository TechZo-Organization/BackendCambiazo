using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Interfaces.REST.Resources;

namespace Backend.Profiles.Interfaces.REST.Transform;

public class BenefitResourceFromEntityAssembler
{
    public static BenefitResource ToResourceFromEntity(Benefit entity)
    {
        return new BenefitResource(entity.Id, entity.Description, entity.MembershipId);
    }
}