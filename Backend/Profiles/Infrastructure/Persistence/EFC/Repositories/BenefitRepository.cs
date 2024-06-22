using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Backend.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class BenefitRepository(AppDbContext context) : BaseRepository<Benefit>(context), IBenefitRepository
{
    
}