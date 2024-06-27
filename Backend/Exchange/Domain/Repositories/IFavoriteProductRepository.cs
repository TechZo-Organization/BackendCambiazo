using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Domain.Repositories;

public interface IFavoriteProductRepository : IBaseRepository<FavoriteProduct>
{
    Task<List<FavoriteProduct>> GetAllByUserId(int userId);
    Task<FavoriteProduct?> GetByUserIdAndProductId(int userId, int productId);

    Task<List<FavoriteProduct>>GetAllFavoriteProductsByUserId(int userId);

}