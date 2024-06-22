using Backend.Exchange.Domain.Model.Commnads.OfferCommands;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class CreateOfferCommandFromResourceAssembler
{
    public static CreateOfferCommand ToCommandFromResource(CreateOfferResource resource)
    {
        return new CreateOfferCommand(resource.ProductOwnerId, resource.ProductExchangeId, resource.State);
    }
}