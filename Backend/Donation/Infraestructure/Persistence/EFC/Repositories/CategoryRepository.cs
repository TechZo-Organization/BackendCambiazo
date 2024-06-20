using Backend.Donation.Domain.Model.Enitities;
using Backend.Donation.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Backend.Donation.Domain.Model.Aggregates;

namespace Backend.Donation.Infraestructure.Persistence.EFC.Repositories;

public class CategoryRepository(AppDbContext context) : BaseRepository<Category>(context) , ICategoryRepository
{
    
    public Task<Category?> FindByName(string name)
    {
        return context.Set<Category>()
            .Where(c => c.Name == name)
            .FirstOrDefaultAsync();

    }
    
}