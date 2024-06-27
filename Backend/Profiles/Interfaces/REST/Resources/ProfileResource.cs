namespace Backend.Profiles.Interfaces.REST.Resources;

public record ProfileResource(int Id, string Name, string Email, string Phone, string Photo, int MembershipId);