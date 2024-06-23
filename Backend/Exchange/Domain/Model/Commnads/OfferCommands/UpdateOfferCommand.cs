
namespace Backend.Exchange.Domain.Model.Commnads.OfferCommands;

public record UpdateOfferCommand(
        int Id,
        int ProductOwnerId,
        int ProductExchangeId,
        string State
    );