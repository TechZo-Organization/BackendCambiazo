namespace Backend.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string FirstName, string LastName, string Email, int Phone, string Photo,int MembershipId);