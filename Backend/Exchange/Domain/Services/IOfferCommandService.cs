using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Commnads.OfferCommands;

namespace Backend.Exchange.Domain.Services;

public interface IOfferCommandService
{
    Task<Offer> Handle(CreateOfferCommand command);
    Task<Offer> Handle(UpdateOfferCommand command);
    Task<Offer> Handle(DeleteOfferCommand command);
}