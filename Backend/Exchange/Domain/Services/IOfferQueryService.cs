using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Queries.OfferQueries;

namespace Backend.Exchange.Domain.Services;

public interface IOfferQueryService
{
    Task<IEnumerable<Offer>> Handle(GetAllOffersQuery query);
}