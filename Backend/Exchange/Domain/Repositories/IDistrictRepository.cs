using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Interfaces.REST.Resources;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Domain.Repositories;

public interface IDistrictRepository : IBaseRepository<District>
{
    Task<District?> GetByNameAsync(string name);
}