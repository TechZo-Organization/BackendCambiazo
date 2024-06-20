using Backend.Donation.Domain.Model.Enitities;
using Backend.Donation.Interfaces.REST.Resources;

namespace Backend.Donation.Interfaces.REST.Transform;

public class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        return new CategoryResource(entity.Id, entity.Name);
    }
}