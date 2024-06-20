using Backend.Donation.Domain.Model.Enitities;

namespace Backend.Donation.Interfaces.REST.Resources;

public record OngResource(
    int Id,
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
    ICollection<Domain.Model.Aggregates.Project> Projects,
    ICollection<Domain.Model.Aggregates.SocialNetwork> SocialNetworks,
    ICollection<Domain.Model.Aggregates.AccountNumber> AccountNumbers,
    Category Category
    );