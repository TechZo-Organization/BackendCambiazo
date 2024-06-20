namespace Backend.Donation.Domain.Model.Commnads.Project;

public record UpdateProjectCommand(
        int Id,
        string Name,
        string Description,
        int OngId
    );