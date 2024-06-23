using Backend.Exchange.Domain.Model.Enitities;

namespace Backend.Exchange.Interfaces.REST.Resources;

public record DepartmentResource(int Id, string Name, Country Country);