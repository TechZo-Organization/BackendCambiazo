using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Exchange.Infraestructure.Persistence.EFC.Repositories;

public class DistrictRepository(AppDbContext context) : BaseRepository<District>(context) , IDistrictRepository
{
    public override async Task<IEnumerable<District>> ListAsync()
    {
        return await Context.Set<District>()
            .Include(d=>d.Department)
            .Include(d=>d.Department.Country)
            .ToListAsync();
    }
    
    public override async Task<District?> FindByIdAsync(int id)
    {
        return await Context.Set<District>()
            .Include(d=>d.Department)
            .Include(d=>d.Department.Country)
            .FirstOrDefaultAsync(d=>d.Id == id);
    }
    
    public async Task<District?> GetByNameAsync(string name)
    {
        return await Context.Set<District>()
            .FirstOrDefaultAsync(d => d.Name == name);
    }
}