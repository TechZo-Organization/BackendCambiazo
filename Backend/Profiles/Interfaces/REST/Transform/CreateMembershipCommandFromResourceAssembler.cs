using Backend.Profiles.Domain.Model.Commands.MembershipCommands;
using Backend.Profiles.Interfaces.REST.Resources;

namespace Backend.Profiles.Interfaces.REST.Transform;

public class CreateMembershipCommandFromResourceAssembler
{
    public static CreateMembershipCommand ToCommandFromResource(CreateMembershipResource resource)
    {
        return new CreateMembershipCommand(resource.Name, resource.Description, resource.Price);
    }
}