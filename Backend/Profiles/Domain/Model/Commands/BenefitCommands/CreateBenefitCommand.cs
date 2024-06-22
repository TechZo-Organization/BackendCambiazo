namespace Backend.Profiles.Domain.Model.Commands.BenefitCommands;

public record CreateBenefitCommand(
        string Description,
        int MembershipId
    );