using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Exchange.Infraestructure.Persistence.EFC.Repositories;

public class DepartmentRepository(AppDbContext context) : BaseRepository<Department>(context) , IDepartmentRepository
{
    public override async Task<IEnumerable<Department>> ListAsync()
    {
        return await Context.Set<Department>()
            .Include(d=>d.Country)
            .ToListAsync();
    }
    
    //by id
    public override async Task<Department?> FindByIdAsync(int id)
    {
        return await Context.Set<Department>()
            .Include(d=>d.Country)
            .FirstOrDefaultAsync(d=>d.Id == id);
    }
    
    public async Task<Department?> GetByNameAsync(string name)
    {
        return await Context.Set<Department>()
            .FirstOrDefaultAsync(d => d.Name == name);
    }
}