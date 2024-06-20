using Backend.Exchange.Domain.Model.Commnads.ProductCategoryCommmands;
using Backend.Exchange.Domain.Model.Enitities;

namespace Backend.Exchange.Domain.Services;

public interface IProductCategoryCommandService
{
    Task<ProductCategory> Handle(CreateProductCategoryCommand command);
    Task<ProductCategory> Handle(UpdateProductCategoryCommand command);
    Task<ProductCategory> Handle(DeleteProductCategoryCommand command);
    
}