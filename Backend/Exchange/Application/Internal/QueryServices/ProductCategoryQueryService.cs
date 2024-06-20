using Backend.Exchange.Domain.Model.Enitities;
using Backend.Exchange.Domain.Model.Queries.ProductCategoryQueries;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Application.Internal.QueryServices;

public class ProductCategoryQueryService(IProductCategoryRepository productCategoryRepository,IUnitOfWork unitOfWork) : IProductCategoryQueryService
{
        
        public async Task<IEnumerable<ProductCategory?>> Handle(GetAllProductCategoriesQuery query)
        {
                return await productCategoryRepository.ListAsync();
        }
        
        
        public async Task<ProductCategory?> Handle(GetProductCategoryByIdQuery query)
        {
                return await productCategoryRepository.FindByIdAsync(query.Id);
        }
    
}