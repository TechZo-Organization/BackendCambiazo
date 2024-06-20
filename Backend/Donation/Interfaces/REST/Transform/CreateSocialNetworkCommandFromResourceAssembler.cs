using Backend.Donation.Domain.Model.Commnads.SocialNetwork;
using Backend.Donation.Interfaces.REST.Resources.SocialNetwork;

namespace Backend.Donation.Interfaces.REST.Transform;

public class CreateSocialNetworkCommandFromResourceAssembler
{
    public static CreateSocialNetworkCommand ToCommandFromResource(CreateSocialNetworkResource resource)
    {
        return new CreateSocialNetworkCommand(
            resource.Name,
            resource.Url,
            resource.Icon,
            resource.OngId);
    }
}