using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Queries.ProductQueries;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository, IUnitOfWork unitOfWork): IProductQueryService
{
    
    public async Task<IEnumerable<Product>> Handle(GetAllAvailableProductsByCategoryIdQuery query)
    {
        return await productRepository.GetAllAvailableProductsByCategoryId(query.CategoryId);
    }
    
    public async Task<IEnumerable<Product>> Handle(GetAllAvailableProductsByWordNameQuery query)
    {
        return await productRepository.GetAllAvailableProductsByWordName(query.WordName);
    }
    
    public async Task<IEnumerable<Product>> Handle(GetAllAvailableProductsByBoostQuery query)
    {
        return await productRepository.GetAllAvailableProductsByBoost(query.Boost);
    }
    
    public async Task<IEnumerable<Product>> Handle(GetAllAvailableProductsByBetweenPricesAndDistrictAndWordNameAndCategoryQuery query)
    {
        return await productRepository.GetAllAvailableProductsBetweenPricesAndDistrictIdAndWordNameAndCategoryId(query.MinPrice, query.MaxPrice, query.DistrictId, query.WordName, query.CategoryId);
    }
    
    public async Task<IEnumerable<Product>> Handle(GetAllProductsByUserAndAvailableQuery query)
    {
        return await productRepository.GetAllProductsByUserAndAvailable(query.UserId, query.Available);
    }
    
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
    {
        return await productRepository.ListAsync();
    }
    
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.Id);
    }
    
    
    
}