using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Exchange.Infraestructure.Persistence.EFC.Repositories;

public class FavoriteProductRepository(AppDbContext context) : BaseRepository<FavoriteProduct>(context) , IFavoriteProductRepository
{
    public  Task<List<FavoriteProduct>> GetAllByUserId(int userId)
    {
        return Context.Set<FavoriteProduct>()
            .Where(f => f.UserId == userId)
            .ToListAsync();
    }
    
    public Task<FavoriteProduct?> GetByUserIdAndProductId(int userId, int productId)
    {
        return Context.Set<FavoriteProduct>()
            .Where(f => f.UserId == userId && f.ProductId == productId)
            .FirstOrDefaultAsync();
    }
    
    public Task<List<FavoriteProduct>>GetAllFavoriteProductsByUserId(int userId)
    {
        return Context.Set<FavoriteProduct>()
            .Where(f => f.UserId == userId)
            .ToListAsync();
    }
}