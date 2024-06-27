using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Exchange.Infraestructure.Persistence.EFC.Repositories;

public class OfferRepository(AppDbContext context) : BaseRepository<Offer>(context), IOfferRepository
{
    public Task<List<Offer>> GetAllOffersByUserOwnIdAsync(int userOwnId)
    {
        return Context.Set<Offer>()
            .Include(o => o.ProductOwner)
            .Where(o => o.ProductOwner.UserId == userOwnId)
            .ToListAsync();
    }
    
    public Task<List<Offer>> GetAllOffersByUserExchangeIdAsync(int userExchangeId)
    {
        return Context.Set<Offer>()
            .Include(o => o.ProductExchange)
            .Where(o => o.ProductExchange.UserId == userExchangeId)
            .ToListAsync();
    }
}