using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product product)
    {
        return new ProductResource(
            product.Id,
            product.Name,
            product.Description,
            product.ObjectChange,
            product.Price,
            product.Photo,
            product.Boost,
            product.Available,
            product.Category,
            product.UserId,
            product.District
        );
    }
}