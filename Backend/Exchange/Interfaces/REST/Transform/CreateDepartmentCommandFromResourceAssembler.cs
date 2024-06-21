using Backend.Exchange.Domain.Model.Commnads.DepartmentCommands;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class CreateDepartmentCommandFromResourceAssembler
{
    public static CreateDepartmentCommand ToCommandFromResource(CreateDepartmentResource resource)
    {
        return new CreateDepartmentCommand(resource.Name, resource.CountryId);
    }
}