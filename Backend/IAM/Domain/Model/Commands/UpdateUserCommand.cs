namespace Backend.IAM.Domain.Model.Commands;

public record UpdateUserCommand(int id,string email,string passwordHash);