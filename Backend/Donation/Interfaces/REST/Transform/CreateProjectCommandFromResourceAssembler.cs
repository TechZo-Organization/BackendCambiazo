using Backend.Donation.Domain.Model.Commnads.Project;
using Backend.Donation.Interfaces.REST.Resources.Project;

namespace Backend.Donation.Interfaces.REST.Transform;

public class CreateProjectCommandFromResourceAssembler
{
    public static CreateProjectCommand ToCommandFromResource(CreateProjectResource resource)
    {
        return new CreateProjectCommand(
            resource.Name,
            resource.Description,
            resource.OngId
        );
    }
}