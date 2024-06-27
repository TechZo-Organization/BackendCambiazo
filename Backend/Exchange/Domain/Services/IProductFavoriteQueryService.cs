using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Queries.FavoriteProductQueries;

namespace Backend.Exchange.Domain.Services;

public interface IProductFavoriteQueryService
{
    Task<IEnumerable<FavoriteProduct>> Handle(GetAllFavoriteProductsQuery query);
    
    Task<IEnumerable<FavoriteProduct>> Handle(GetAllFavoriteProductsByUserIdQuery query);
    
}