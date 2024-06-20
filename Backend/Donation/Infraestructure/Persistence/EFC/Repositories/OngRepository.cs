using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Backend.Donation.Domain.Model.Commnads;

namespace Backend.Donation.Infraestructure.Persistence.EFC.Repositories;

public class OngRepository(AppDbContext context): BaseRepository<Ong>(context) , IOngRepository
{
    public async Task<IEnumerable<Ong>> GetAllByWordName(string wordName)
    {
        return await context.Set<Ong>()
            .Where(o => o.Name.Contains(wordName))
            .Include(o=>o.Category)
            .Include(o=>o.Projects)
            .Include(o=>o.SocialNetworks)
            .Include(o=>o.AccountNumbers)
            .ToListAsync();
    }

    public async Task<IEnumerable<Ong>> GetAllByWordAddress(string wordAddress)
    {
        
        return await context.Set<Ong>()
            .Where(o => o.Address.Contains(wordAddress))
            .Include(o=>o.Category)
            .Include(o=>o.Projects)
            .Include(o=>o.SocialNetworks)
            .Include(o=>o.AccountNumbers)
            .ToListAsync();
    }

    public async Task<IEnumerable<Ong>> GetAllByCategory(int categoryId)
    {
        return await context.Set<Ong>()
            .Where(o => o.CategoryId == categoryId)
            .Include(o=>o.Category)
            .Include(o=>o.Projects)
            .Include(o=>o.SocialNetworks)
            .Include(o=>o.AccountNumbers)
            .ToListAsync();
    }

    public override async Task<IEnumerable<Ong>> ListAsync()
    {
        return await context.Set<Ong>()
            .Include(o=>o.Category)
            .Include(o=>o.Projects)
            .Include(o=>o.SocialNetworks)
            .Include(o=>o.AccountNumbers)
            .ToListAsync();
    }
    
    public override async Task<Ong?> FindByIdAsync(int id)
    {
        return await context.Set<Ong>()
            .Include(o=>o.Category)
            .Include(o=>o.Projects)
            .Include(o=>o.SocialNetworks)
            .Include(o=>o.AccountNumbers)
            .FirstOrDefaultAsync(o => o.Id == id);
    }
    
}