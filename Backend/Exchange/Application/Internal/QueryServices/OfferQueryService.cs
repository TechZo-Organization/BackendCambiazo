using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Queries.OfferQueries;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;

namespace Backend.Exchange.Application.Internal.QueryServices;

public class OfferQueryService(IOfferRepository offerRepository): IOfferQueryService
{
    public async Task <IEnumerable<Offer>> Handle(GetAllOffersQuery query)
    {
        return await offerRepository.ListAsync();
    }
}