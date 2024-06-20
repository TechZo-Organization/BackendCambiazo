using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Interfaces.REST.Resources.Project;

namespace Backend.Donation.Interfaces.REST.Transform;

public class ResourceProjectFromEntityAssembler
{
    public static ProjectResource ToResourceFromEntity(Project project)
    {
        return new ProjectResource(
            project.Id,
            project.Name,
            project.Description,
            project.OngId
        );
    }
}