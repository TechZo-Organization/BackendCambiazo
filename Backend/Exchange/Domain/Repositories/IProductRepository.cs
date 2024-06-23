using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product> 
{
    
    //methods for user profile
    Task<List<Product>> GetAllProductsByUserAndAvailable(int userId, bool available);
    
    
    //methods for search
    Task<List<Product>> GetAllAvailableProductsByCategoryId(int categoryId);
    Task<List<Product>> GetAllAvailableProductsByWordName(string wordName);
    Task<List<Product>> GetAllAvailableProductsByBoost(bool boost);
    Task<List<Product>> GetAllAvailableProductsBetweenPricesAndDistrictIdAndWordNameAndCategoryId
    (float minPrice, float maxPrice,
        int districtId,
        string wordName,
        int categoryId);
    

}