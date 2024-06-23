namespace Backend.Profiles.Interfaces.REST.Resources;

public record CreateBenefitResource(
    string Description,
    int MembershipId
    );