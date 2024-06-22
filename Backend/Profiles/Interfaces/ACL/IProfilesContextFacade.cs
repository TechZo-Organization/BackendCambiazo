namespace Backend.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string firstName, string lastName, string email, int phone, string photo, int membershipId);

    Task<int> FetchProfileIdByEmail(string email);
}