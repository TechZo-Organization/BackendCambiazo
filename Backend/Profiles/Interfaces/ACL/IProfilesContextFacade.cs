namespace Backend.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string name, string email, string phone, string photo, int membershipId);

    Task<int> FetchProfileIdByEmail(string email);
}