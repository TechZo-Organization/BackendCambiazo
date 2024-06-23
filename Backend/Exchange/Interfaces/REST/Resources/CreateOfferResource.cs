
namespace Backend.Exchange.Interfaces.REST.Resources;

public record CreateOfferResource(
    int ProductOwnerId,
    int ProductExchangeId,
    string State
    );