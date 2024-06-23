namespace Backend.Exchange.Domain.Model.Commnads.DepartmentCommands;

public record CreateDepartmentCommand(string Name, int CountryId);