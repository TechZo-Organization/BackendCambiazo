namespace Backend.Exchange.Domain.Model.Commnads.DistrictCommands;

public record CreateDistrictCommand(string Name, int DepartmentId);