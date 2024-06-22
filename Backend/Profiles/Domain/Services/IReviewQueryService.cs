using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.Commands.ReviewCommands;
using Backend.Profiles.Domain.Model.Queries.ReviewQueries;

namespace Backend.Profiles.Domain.Services;

public interface IReviewQueryService
{
    Task<IEnumerable<Review>> Handle(GetAllReviewsQuery query);
    Task<Review?> Handle(GetReviewByIdQuery query);
}