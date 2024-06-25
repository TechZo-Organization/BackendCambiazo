namespace Backend.Profiles.Interfaces.REST.Resources;

public record ReviewResource(
    int Id,
    string Message,
    string State,
    int ProfileAuthorId,
    int ProfileReceptorId,
    int OfferId
    );