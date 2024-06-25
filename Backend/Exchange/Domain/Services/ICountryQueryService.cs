using Backend.Exchange.Domain.Model.Enitities;
using Backend.Exchange.Domain.Model.Queries.CountryQueries;

namespace Backend.Exchange.Domain.Services;

public interface ICountryQueryService
{
    Task<IEnumerable<Country>> Handle(GetAllCountriesQuery query);
}