
namespace Backend.Exchange.Interfaces.REST.Resources;

public record OfferResource(
        int Id,
        int ProductOwnerId,
        int ProductExchangeId,
        string State
    );