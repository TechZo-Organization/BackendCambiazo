using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Queries.DistrictQueries;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;

namespace Backend.Exchange.Application.Internal.QueryServices;

public class DistrictQueryService(IDistrictRepository districtRepository) : IDistrictQueryService
{

    public async Task<IEnumerable<District>> Handle(GetAllDistrictsQuery query)
    {
        return await districtRepository.ListAsync();
    }
    
    public async Task<District?> Handle(GetDistrictByIdQuery query)
    {
        return await districtRepository.FindByIdAsync(query.Id);
    }
    
    
    
}