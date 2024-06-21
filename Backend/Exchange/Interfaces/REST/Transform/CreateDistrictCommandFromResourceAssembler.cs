using Backend.Exchange.Domain.Model.Commnads.DistrictCommands;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class CreateDistrictCommandFromResourceAssembler
{
    public static CreateDistrictCommand ToCommandFromResource(CreateDistrictResource resource)
    {
        return new CreateDistrictCommand(resource.Name, resource.DepartmentId);
    }
}