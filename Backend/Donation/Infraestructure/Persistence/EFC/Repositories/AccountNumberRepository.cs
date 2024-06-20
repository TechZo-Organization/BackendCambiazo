using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Backend.Donation.Infraestructure.Persistence.EFC.Repositories;

public class AccountNumberRepository(AppDbContext context) : BaseRepository<AccountNumber>(context), IAccountNumberRepository
{
    
}