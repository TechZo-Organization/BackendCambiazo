namespace Backend.Donation.Interfaces.REST.Resources.SocialNetwork;

public record SocialNetworkResource(
        int Id,
        string Name,
        string Url,
        string Icon,
        int OngId
    );