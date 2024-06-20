namespace Backend.Donation.Interfaces.REST.Resources.Project;

public record ProjectResource(
       int Id,
        string Name,
        string Description,
        int OngId
    );