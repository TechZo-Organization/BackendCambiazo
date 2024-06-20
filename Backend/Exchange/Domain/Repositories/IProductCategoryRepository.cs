using Backend.Exchange.Domain.Model.Enitities;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Domain.Repositories;

public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
{
    Task<ProductCategory?> FindByName(string name);

}