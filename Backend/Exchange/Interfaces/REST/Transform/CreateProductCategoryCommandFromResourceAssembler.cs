using Backend.Exchange.Domain.Model.Commnads.ProductCategoryCommmands;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class CreateProductCategoryCommandFromResourceAssembler
{
    public static CreateProductCategoryCommand ToCommandFromResource(CreateProductCategoryResource resource)
    {
        return new CreateProductCategoryCommand(resource.Name);
    }
}