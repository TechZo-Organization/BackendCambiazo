using Backend.Exchange.Domain.Model.Enitities;
using Backend.Exchange.Domain.Model.Queries.ProductCategoryQueries;

namespace Backend.Exchange.Domain.Services;

public interface IProductCategoryQueryService
{
    Task<IEnumerable<ProductCategory?>> Handle(GetAllProductCategoriesQuery query);
    Task<ProductCategory?> Handle(GetProductCategoryByIdQuery query);
}