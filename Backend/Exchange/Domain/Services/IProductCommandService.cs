using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Commnads.ProductCommands;

namespace Backend.Exchange.Domain.Services;

public interface IProductCommandService
{
    Task<Product> Handle(CreateProductCommand command);
    Task<Product> Handle(UpdateProductCommand command);
    Task<Product> Handle(DeleteProductCommand command);
}