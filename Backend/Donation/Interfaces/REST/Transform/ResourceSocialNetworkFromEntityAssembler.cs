using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Interfaces.REST.Resources.SocialNetwork;

namespace Backend.Donation.Interfaces.REST.Transform;

public class ResourceSocialNetworkFromEntityAssembler
{
    public static SocialNetworkResource ToResourceFromEntity(SocialNetwork socialNetwork)
    {
        return new SocialNetworkResource(
            socialNetwork.Id,
            socialNetwork.Name,
            socialNetwork.Url,
            socialNetwork.Icon,
            socialNetwork.OngId
        );
    }
}