using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Commnads.FavoriteProductcommands;

namespace Backend.Exchange.Domain.Services;

public interface IFavoriteProductCommandService
{
    Task<FavoriteProduct> Handle(CreateFavoriteProductCommand command);
    Task<FavoriteProduct> Handle(DeleteFavoriteProductCommand command);
}