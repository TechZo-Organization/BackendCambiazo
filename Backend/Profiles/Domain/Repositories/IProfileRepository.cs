using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.ValueObjects;
using Backend.Shared.Domain.Repositories;

namespace Backend.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
}