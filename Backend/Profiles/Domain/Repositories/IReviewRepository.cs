using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend.Profiles.Domain.Repositories;

public interface IReviewRepository: IBaseRepository<Review>
{
    Task<Review?> FindByAuthorIdAndReceptorIdAndOffer(int authorId, int receptorId, int offerId);
}