namespace Backend.Profiles.Interfaces.REST.Resources;

public record BenefitResource(
    int Id,
    string Description,
    int MembershipId
    );