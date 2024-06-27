namespace Backend.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(string Name, string Email, string Phone, string Photo, int MembershipId);