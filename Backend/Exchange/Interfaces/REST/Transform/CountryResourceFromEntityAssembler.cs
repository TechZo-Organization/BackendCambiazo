using Backend.Exchange.Domain.Model.Enitities;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class CountryResourceFromEntityAssembler
{
    public static CountryResource ToResourceFromEntity(Country entity)
    {
        return new CountryResource(entity.Id, entity.Name, entity.Departments);
    }
}