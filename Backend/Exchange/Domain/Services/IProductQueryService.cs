using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Queries.ProductQueries;

namespace Backend.Exchange.Domain.Services;

public interface IProductQueryService
{
  
    Task<Product?> Handle(GetProductByIdQuery query);
    Task<IEnumerable<Product>> Handle(GetAllProductsQuery query);
    
    Task<IEnumerable<Product>> Handle(GetAllProductsByUserAndAvailableQuery query);
    
    Task<IEnumerable<Product>> Handle(GetAllAvailableProductsByCategoryIdQuery query);
    Task<IEnumerable<Product>> Handle(GetAllAvailableProductsByWordNameQuery query);
    Task<IEnumerable<Product>> Handle(GetAllAvailableProductsByBoostQuery query);
    Task<IEnumerable<Product>> Handle(GetAllAvailableProductsByBetweenPricesAndDistrictAndWordNameAndCategoryQuery query);
    
    
    
}