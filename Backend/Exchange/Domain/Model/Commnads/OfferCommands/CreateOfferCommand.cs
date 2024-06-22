
namespace Backend.Exchange.Domain.Model.Commnads.OfferCommands;

public record CreateOfferCommand(
        int ProductOwnerId,
        int ProductExchangeId,
        string State
    );