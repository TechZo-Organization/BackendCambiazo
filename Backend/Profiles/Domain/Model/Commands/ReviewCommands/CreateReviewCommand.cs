namespace Backend.Profiles.Domain.Model.Commands.ReviewCommands;

public record CreateReviewCommand(
    string Message,
    int Score,
    string State,
    int UserAuthorId,
    int UserReceptorId,
    int OfferId
    );