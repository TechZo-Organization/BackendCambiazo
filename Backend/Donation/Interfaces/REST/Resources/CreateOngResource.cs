namespace Backend.Donation.Interfaces.REST.Resources;

public record CreateOngResource(
    string Name,
    string Type,
    string AboutUs,
    string MissionVision,
    string SupportForm,
    string Address,
    string Email,
    string Number,
    string UrlLogo,
    string UrlWebSite,
    string AttentionSchedule,
    int CategoryId
);
