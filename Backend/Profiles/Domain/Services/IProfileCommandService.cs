using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.Commands;

namespace Backend.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}