namespace Backend.Profiles.Domain.Model.Commands.MembershipCommands;

public record UpdateMembershipCommand(
        int Id,
        string Name,
        string Description,
        float Price
    );