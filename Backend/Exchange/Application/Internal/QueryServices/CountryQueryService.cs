using Backend.Exchange.Domain.Model.Enitities;
using Backend.Exchange.Domain.Model.Queries.CountryQueries;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;

namespace Backend.Exchange.Application.Internal.QueryServices;

public class CountryQueryService(ICountryRepository repository) : ICountryQueryService
{
    public async Task<IEnumerable<Country>> Handle(GetAllCountriesQuery query)
    {
        return await repository.ListAsync();
    }
}