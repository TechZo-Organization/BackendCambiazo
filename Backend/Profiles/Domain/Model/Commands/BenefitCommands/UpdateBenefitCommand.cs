namespace Backend.Profiles.Domain.Model.Commands.BenefitCommands;

public record UpdateBenefitCommand(
        int Id,
        string Description,
        int MembershipId
    );