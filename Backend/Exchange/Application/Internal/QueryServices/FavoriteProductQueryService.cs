using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Queries.FavoriteProductQueries;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;

namespace Backend.Exchange.Application.Internal.QueryServices;

public class FavoriteProductQueryService(IFavoriteProductRepository favoriteProductRepository) : IProductFavoriteQueryService
{
    
    public async Task<IEnumerable<FavoriteProduct>> Handle(GetAllFavoriteProductsQuery query)
    {
        return await favoriteProductRepository.ListAsync();
    }
    
    public async Task<IEnumerable<FavoriteProduct>> Handle(GetAllFavoriteProductsQueryByUserQuery query)
    {
        return await favoriteProductRepository.GetAllByUserId(query.UserId);
    }
    
    
}