using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class DepartmentResourceFromEntityAssembler
{
    public static DepartmentResource ToResourceFromEntity(Department entity)
    {
        return new DepartmentResource(entity.Id, entity.Name, entity.Country);
    }
}