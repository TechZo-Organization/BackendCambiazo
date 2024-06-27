using Backend.Donation.Domain.Model.Queries.Category;
using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Queries.DistrictQueries;

namespace Backend.Exchange.Domain.Services;

public interface IDistrictQueryService
{
    Task<IEnumerable<District>> Handle(GetAllDistrictsQuery query);
    Task<District?> Handle(GetDistrictByNameQuery query);
}