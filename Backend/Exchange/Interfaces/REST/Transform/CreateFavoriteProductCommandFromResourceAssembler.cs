using Backend.Exchange.Domain.Model.Commnads.FavoriteProductcommands;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class CreateFavoriteProductCommandFromResourceAssembler
{
    public static CreateFavoriteProductCommand ToCommandFromResource(CreateFavoriteProductResource resource)
    {
        return new CreateFavoriteProductCommand(resource.UserId, resource.ProductId);
    }
}