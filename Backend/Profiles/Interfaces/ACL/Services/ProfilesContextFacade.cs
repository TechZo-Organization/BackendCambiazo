using Backend.Profiles.Domain.Model.Commands;
using Backend.Profiles.Domain.Model.Queries;
using Backend.Profiles.Domain.Model.ValueObjects;
using Backend.Profiles.Domain.Services;

namespace Backend.Profiles.Interfaces.ACL.Services;

public class ProfilesContextFacade(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService) : IProfilesContextFacade
{
    public async Task<int> CreateProfile(string firstName, string lastName, string email, int phone, string photo,int membershipId)
    {
        var createProfileCommand = new CreateProfileCommand(firstName, lastName, email, phone, photo,membershipId);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }

    public async Task<int> FetchProfileIdByEmail(string email)
    {
        var getProfileByEmailQuery = new GetProfileByEmailQuery(new EmailAddress(email));
        var profile = await profileQueryService.Handle(getProfileByEmailQuery);
        return profile?.Id ?? 0;
    }
}