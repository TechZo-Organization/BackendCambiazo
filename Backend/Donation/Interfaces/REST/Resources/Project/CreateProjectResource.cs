namespace Backend.Donation.Interfaces.REST.Resources.Project;

public record CreateProjectResource(
    string Name,
    string Description,
    int OngId);