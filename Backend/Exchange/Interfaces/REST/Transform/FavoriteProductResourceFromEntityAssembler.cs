using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class FavoriteProductResourceFromEntityAssembler
{
    public static FavoriteProductResource ToResourceFromEntity(FavoriteProduct favoriteProduct)
    {
        return new FavoriteProductResource(favoriteProduct.Id, favoriteProduct.UserId, favoriteProduct.ProductId);
    }
}