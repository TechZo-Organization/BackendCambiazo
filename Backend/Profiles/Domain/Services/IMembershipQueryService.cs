using Backend.Profiles.Domain.Model.Entities;
using Backend.Profiles.Domain.Model.Queries.MembershipQueries;

namespace Backend.Profiles.Domain.Services;

public interface IMembershipQueryService
{
    Task<IEnumerable<Membership>> Handle(GetAllMembershipsQuery query);
}