using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Enitities;

namespace Backend.Exchange.Interfaces.REST.Resources;

public record DepartmentResource(int Id, string Name,  List<  string> Cities );