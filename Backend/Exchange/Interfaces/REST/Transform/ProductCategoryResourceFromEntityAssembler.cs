using Backend.Exchange.Domain.Model.Enitities;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class ProductCategoryResourceFromEntityAssembler
{
    public static ProductCategoryResource ToResourceFromEntity(ProductCategory category)
    {
        return new ProductCategoryResource(
            category.Id,
            category.Name
            );

    }
}