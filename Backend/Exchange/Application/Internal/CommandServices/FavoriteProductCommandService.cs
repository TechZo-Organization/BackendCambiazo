using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Commnads.FavoriteProductcommands;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;
using Backend.Profiles.Domain.Repositories;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Application.Internal.CommandServices;

public class FavoriteProductCommandService(IFavoriteProductRepository favoriteProductRepository,IProfileRepository profileRepository,IUnitOfWork unitOfWork) : IFavoriteProductCommandService
{
    
    public async Task<FavoriteProduct> Handle(CreateFavoriteProductCommand command)
    {
        try
        {
            
            //validate exist product
            var product = await profileRepository.FindByIdAsync(command.ProductId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            //validate exist user
            var user = await profileRepository.FindByIdAsync(command.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            
            var favoriteProductExist = await favoriteProductRepository.GetByUserIdAndProductId(command.UserId, command.ProductId);
            if (favoriteProductExist != null)
            {
                throw new Exception("Favorite product already exist");
            }
            
            var favoriteProduct = new FavoriteProduct(command.UserId, command.ProductId);
            await favoriteProductRepository.AddAsync(favoriteProduct);
            await unitOfWork.CompleteAsync();
            return favoriteProduct;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the offer: {e.Message}");
            return null;
        }
    }
    
    public async Task<FavoriteProduct> Handle(DeleteFavoriteProductCommand command)
    {
        try
        {
            var favoriteProduct = await favoriteProductRepository.FindByIdAsync(command.Id);
            if (favoriteProduct == null)
            {
                throw new Exception("Favorite product not found");
            }
            favoriteProductRepository.Remove(favoriteProduct);
            await unitOfWork.CompleteAsync();
            return favoriteProduct;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the offer: {e.Message}");
            return null;
        }
    }
    
    
}