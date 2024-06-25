using Backend.Profiles.Domain.Model.Aggregates;

namespace Backend.Profiles.Interfaces.REST.Resources;

public record MembershipResource(
    int Id,
        string Name,
        string Description,
        float Price,
    List<string> Benefits);