using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class OfferResourceFromEntityAssembler
{
    public static OfferResource ToResourceFromEntity(Offer entity)
    {
        return new OfferResource(entity.Id, entity.ProductOwnerId, entity.ProductExchangeId, entity.State);
    }
}