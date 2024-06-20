namespace Backend.Donation.Domain.Model.Commnads.SocialNetwork;

public record UpdateSocialNetworkCommand(
    int Id,
        string Name,
        string Url,
        string Icon,
        int OngId
    );