namespace Backend.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string Name, string Email, string Phone, string Photo,int MembershipId);