namespace Backend.Exchange.Domain.Model.Commnads.DepartmentCommands;

public record UpdateDepartmentCommand(int Id, string Name, int CountryId);