namespace Backend.Profiles.Interfaces.REST.Resources;

public record CreateReviewResource(
        string Message,
        string State,
        int ProfileAuthorId,
        int ProfileReceptorId,
        int OfferId
    );