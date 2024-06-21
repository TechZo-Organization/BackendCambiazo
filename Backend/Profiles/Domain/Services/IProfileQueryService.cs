using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.Queries;

namespace Backend.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    Task<Profile?> Handle(GetProfileByEmailQuery query);
    Task<Profile?> Handle(GetProfileByIdQuery query);
}