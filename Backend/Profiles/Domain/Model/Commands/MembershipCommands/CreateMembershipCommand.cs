namespace Backend.Profiles.Domain.Model.Commands.MembershipCommands;

public record CreateMembershipCommand(
        string Name,
        string Description,
        float Price
    );