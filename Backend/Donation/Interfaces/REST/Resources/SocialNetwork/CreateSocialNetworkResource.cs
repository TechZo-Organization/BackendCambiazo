namespace Backend.Donation.Interfaces.REST.Resources.SocialNetwork;

public record CreateSocialNetworkResource(
    string Name,
    string Url,
    string Icon,
    int OngId
    );