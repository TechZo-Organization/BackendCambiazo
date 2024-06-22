using Backend.Profiles.Domain.Model.Entities;
using Backend.Profiles.Domain.Model.Queries.MembershipQueries;
using Backend.Profiles.Domain.Repositories;
using Backend.Profiles.Domain.Services;

namespace Backend.Profiles.Application.Internal.QueryServices;

public class MembershipQueryService(IMembershipRepository membershipRepository): IMembershipQueryService
{

    public async Task<IEnumerable<Membership>> Handle(GetAllMembershipsQuery query)
    {
        return await membershipRepository.ListAsync();
    }
    
}