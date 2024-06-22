namespace Backend.Profiles.Interfaces.REST.Resources;

public record CreateMembershipResource(
        string Name,
        string Description,
        float Price);