using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.Commands.ReviewCommands;

namespace Backend.Profiles.Domain.Services;

public interface IReviewCommandService
{
    Task<Review> Handle(CreateReviewCommand command);
    Task<Review> Handle(DeleteReviewCommand command);
}