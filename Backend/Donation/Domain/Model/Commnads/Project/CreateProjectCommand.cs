namespace Backend.Donation.Domain.Model.Commnads.Project;

public record CreateProjectCommand(string Name,string Description,int OngId);