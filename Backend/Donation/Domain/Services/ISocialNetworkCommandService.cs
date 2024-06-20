using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Model.Commnads.SocialNetwork;

namespace Backend.Donation.Domain.Services;

public interface ISocialNetworkCommandService
{
    Task<SocialNetwork> Handle(CreateSocialNetworkCommand command);
    Task<SocialNetwork> Handle(UpdateSocialNetworkCommand command);
    Task<SocialNetwork> Handle(DeleteSocialNetworkCommand command);

}