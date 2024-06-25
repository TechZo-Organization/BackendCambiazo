using Backend.Profiles.Domain.Model.Entities;
using Backend.Profiles.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class MembershipRepository(AppDbContext context) : BaseRepository<Membership>(context), IMembershipRepository
{
    public override async Task<IEnumerable<Membership>> ListAsync()
    {
        return await context.Set<Membership>()
            .Include(p=>p.Benefits)
            .ToListAsync();
    }
}