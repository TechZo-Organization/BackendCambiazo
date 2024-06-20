namespace Backend.Donation.Domain.Model.Commnads.SocialNetwork;

public record CreateSocialNetworkCommand(
        string Name,
        string Url,
        string Icon,
        int OngId
    );