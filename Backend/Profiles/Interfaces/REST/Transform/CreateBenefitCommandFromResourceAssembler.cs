using Backend.Profiles.Domain.Model.Commands.BenefitCommands;
using Backend.Profiles.Interfaces.REST.Resources;

namespace Backend.Profiles.Interfaces.REST.Transform;

public class CreateBenefitCommandFromResourceAssembler
{
    public static CreateBenefitCommand ToCommandFromResource(CreateBenefitResource resource)
    {
        return new CreateBenefitCommand(resource.Description, resource.MembershipId);
    }
}