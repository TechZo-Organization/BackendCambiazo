using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Exchange.Infraestructure.Persistence.EFC.Repositories;

public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    
    public Task<List<Product>> GetAllProductsByUserAndAvailable(int userId, bool available)
    {
        return context.Set<Product>()
            .Where(p => p.UserId == userId && p.Available == available)
            .Include(p=>p.Category)
            .Include(p=> p.District)
            .Include(p=> p.District.Department)
            .Include(p => p.District.Department.Country)
            .ToListAsync();
    }

    public Task<List<Product>> GetAllAvailableProductsByWordName(string wordName)
    {
        var query = context.Set<Product>().AsQueryable();
        if (!string.IsNullOrEmpty(wordName)) query = query.Where(p => p.Name.Contains(wordName));
        query = query.Where(p => p.Available && p.Boost);
        query = query.Include(p => p.Category);
        query = query.Include(p => p.District);
        query = query.Include(p => p.District.Department);
        query = query.Include(p => p.District.Department.Country);
        return query.ToListAsync();
    }

    public Task<List<Product>> GetAllAvailableProductsByBoost(bool boost)
    {
        return context.Set<Product>()
            .Where(p => p.Boost == boost && p.Available)
            .Include(p=>p.Category)
            .Include(p=> p.District)
            .Include(p=> p.District.Department)
            .Include(p => p.District.Department.Country)
            .ToListAsync();
    }
    
    public Task<List<Product>> GetAllAvailableProductsBetweenPricesAndDistrictIdAndWordNameAndCategoryId(float minPrice,
        float maxPrice, int districtId, string wordName, int categoryId)
    {
        var query = context.Set<Product>().AsQueryable();
    
        if (minPrice != 0) query = query.Where(p => p.Price >= minPrice);
        if (maxPrice != 0) query = query.Where(p => p.Price <= maxPrice);
        if (districtId != 0) query = query.Where(p => p.DistrictId == districtId);
        if (!string.IsNullOrEmpty(wordName)) query = query.Where(p => p.Name.Contains(wordName));
        if (categoryId != 0)query = query.Where(p => p.CategoryId == categoryId);
        query = query.Where(p => p.Available);
        query = query.Include(p => p.Category);
        query = query.Include(p => p.District);
        query = query.Include(p => p.District.Department);
        query = query.Include(p => p.District.Department.Country);



        return query.ToListAsync();
    }
    
    public Task<List<Product>> GetAllAvailableProductsByCategoryId(int categoryId)
    {
        return context.Set<Product>()
            .Where(p => p.CategoryId == categoryId && p.Available && p.Boost)
            .Include(p=>p.Category)
            .Include(p=> p.District)
            .Include(p=> p.District.Department)
            .Include(p => p.District.Department.Country)
            .ToListAsync();
    }

    public override async  Task<IEnumerable<Product>> ListAsync()
    {
        return await context.Set<Product>()
            .Include(p=>p.Category)
            .Include(p=> p.District)
            .Include(p=> p.District.Department)
            .Include(p => p.District.Department.Country)
            .ToListAsync();
    }
    
    public override async Task<Product?> FindByIdAsync(int id)
    {
        return await context.Set<Product>()
            .Include(p=>p.Category)
            .Include(p=> p.District)
            .Include(p=> p.District.Department)
            .Include(p => p.District.Department.Country)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}