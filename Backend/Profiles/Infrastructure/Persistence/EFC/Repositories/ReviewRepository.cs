using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Backend.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ReviewRepository(AppDbContext context): BaseRepository<Review>(context), IReviewRepository
{
    
}