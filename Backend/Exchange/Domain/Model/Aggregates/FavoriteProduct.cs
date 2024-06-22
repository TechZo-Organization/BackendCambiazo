using Backend.Exchange.Domain.Model.Commnads.FavoriteProductcommands;
using Backend.Profiles.Domain.Model.Aggregates;

namespace Backend.Exchange.Domain.Model.Aggregates;

public class FavoriteProduct
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    
    public Profile User { get; set; }
    public Product Product { get; set; }
    
    public FavoriteProduct(int userId, int productId)
    {
        UserId = userId;
        ProductId = productId;
    }
    
    public FavoriteProduct(CreateFavoriteProductCommand command)
    {
        UserId = command.UserId;
        ProductId = command.ProductId;
    }
    
    
}