using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class DistrictResourceFromEntityAssembler
{
    public static DistrictResource ToResourceFromEntity(District entity)
    {
        return new DistrictResource(entity.Id, entity.Name);
    }
}