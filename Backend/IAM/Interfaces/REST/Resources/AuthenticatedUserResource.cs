namespace Backend.IAM.Interfaces.REST.Resources;

public record AuthenticatedUserResource(int Id, string Email, string Token);