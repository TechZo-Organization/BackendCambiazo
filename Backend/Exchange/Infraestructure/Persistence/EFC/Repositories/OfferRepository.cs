using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Backend.Exchange.Infraestructure.Persistence.EFC.Repositories;

public class OfferRepository(AppDbContext context) : BaseRepository<Offer>(context), IOfferRepository
{
    
}