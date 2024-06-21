using Backend.Exchange.Domain.Model.Commnads.ProductCommands;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new CreateProductCommand(
            resource.Name,
            resource.Description,
            resource.ObjectChange,
            resource.Price,
            resource.Photo,
            resource.Boost,
            resource.Available,
            resource.CategoryId,
            resource.UserId,
            resource.DistrictId
        );
    }
}