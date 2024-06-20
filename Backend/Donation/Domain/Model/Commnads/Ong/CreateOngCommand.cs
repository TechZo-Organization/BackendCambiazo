namespace Backend.Donation.Domain.Model.Commnads.Ong;

public record CreateOngCommand(
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