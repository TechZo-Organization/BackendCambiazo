using Backend.Exchange.Domain.Model.Aggregates;

namespace Backend.Exchange.Interfaces.REST.Resources;

public record DistrictResource(int Id, string Name, Department Department);