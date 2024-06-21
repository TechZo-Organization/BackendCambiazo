namespace Backend.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(string FirstName, string LastName, string Email, int Phone, string Photo);