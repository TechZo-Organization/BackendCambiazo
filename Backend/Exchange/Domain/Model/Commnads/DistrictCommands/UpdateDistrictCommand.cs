namespace Backend.Exchange.Domain.Model.Commnads.DistrictCommands;

public record UpdateDistrictCommand(int Id, string Name, int DepartmentId);