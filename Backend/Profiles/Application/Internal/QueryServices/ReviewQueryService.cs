using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.Queries.ReviewQueries;
using Backend.Profiles.Domain.Repositories;
using Backend.Profiles.Domain.Services;

namespace Backend.Profiles.Application.Internal.QueryServices;

public class ReviewQueryService(IReviewRepository reviewRepository) : IReviewQueryService
{

    public async Task<IEnumerable<Review>> Handle(GetAllReviewsQuery query)
    {
        return await reviewRepository.ListAsync();
    }
    
    public async Task<Review?> Handle(GetReviewByIdQuery query)
    {
        return await reviewRepository.FindByIdAsync(query.Id);
    }

}
