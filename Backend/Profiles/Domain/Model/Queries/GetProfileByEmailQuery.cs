using Backend.Profiles.Domain.Model.ValueObjects;

namespace Backend.Profiles.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);