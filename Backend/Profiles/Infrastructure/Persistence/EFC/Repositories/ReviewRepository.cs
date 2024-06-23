using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ReviewRepository(AppDbContext context): BaseRepository<Review>(context), IReviewRepository
{
    Task<Review?> IReviewRepository.FindByAuthorIdAndReceptorIdAndOffer(int authorId, int receptorId, int offerId)
    {
        return Context.Set<Review>()
            .Where(r => r.ProfileAuthorId == authorId && r.ProfileReceptorId == receptorId && r.OfferId == offerId)
            .FirstOrDefaultAsync();
    }
  
}