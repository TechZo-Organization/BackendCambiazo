using System.Text.Json.Serialization;
using Backend.Exchange.Domain.Model.Aggregates;

namespace Backend.Exchange.Interfaces.REST.Resources;

public record CountryResource(int Id, string Name,  ICollection<Department> Departments);