using Backend.Exchange.Domain.Model.Enitities;
using Backend.Exchange.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Exchange.Infraestructure.Persistence.EFC.Repositories;

public class ProductCategoryRepository(AppDbContext context) : BaseRepository<ProductCategory>(context) , IProductCategoryRepository
{
    public Task<ProductCategory?> FindByName(string name)
    {
        return context.Set<ProductCategory>()
            .Where(c => c.Name == name)
            .FirstOrDefaultAsync();

    }
}