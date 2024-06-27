using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Domain.Repositories;

public interface IOfferRepository: IBaseRepository<Offer>
{
    Task<List<Offer>>GetAllOffersByUserOwnIdAsync(int userOwnId);
    
    Task<List<Offer>>GetAllOffersByUserExchangeIdAsync(int userExchangeId);
}