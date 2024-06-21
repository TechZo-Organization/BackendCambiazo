using Backend.Exchange.Domain.Model.Enitities;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Domain.Repositories;

public interface ICountryRepository : IBaseRepository<Country>
{
    Task<Country?> GetByNameAsync(string name);
}