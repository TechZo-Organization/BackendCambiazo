using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Commnads.OfferCommands;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Application.Internal.CommandServices;

public class OfferCommandService(IOfferRepository offerRepository,IProductRepository productRepository,IUnitOfWork unitOfWork): IOfferCommandService
{
    public async Task<Offer> Handle(CreateOfferCommand command)
    {
        try
        {
            var product2 = await productRepository.FindByIdAsync(command.ProductOwnerId);
            var product1 = await productRepository.FindByIdAsync(command.ProductExchangeId);
            
            if(command.State != "Pending" && command.State != "Accepted" && command.State != "Rejected")
            {
                throw new Exception("Invalid state");
            }
            if(product1 == null || product2 == null)
            {
                throw new Exception("Product not found");
            }
            //validate available product
            if(product1.Available == false  || product2.Available == false)
            {
                throw new Exception("Product not available");
            }
            
            
            var offer = new Offer(command);
            await offerRepository.AddAsync(offer);
            await unitOfWork.CompleteAsync();
            return offer;
        }
        catch(Exception e)
        {
            Console.WriteLine($"An error occurred while creating the offer: {e.Message}");
            return null;
            
        }
    }
    
    public async Task<Offer> Handle(DeleteOfferCommand command)
    {
        try
        {
            var offer = await offerRepository.FindByIdAsync(command.Id);
            if(offer == null)
            {
                throw new Exception("Offer not found");
            }
            
            offerRepository.Remove(offer);
            await unitOfWork.CompleteAsync();
            return offer;
        }
        catch(Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the offer: {e.Message}");
            return null;
        }
    }
    
    public async Task<Offer> Handle(UpdateOfferCommand command)
    {
        try
        {
            var offer = await offerRepository.FindByIdAsync(command.Id);
            if(offer == null)
            {
                throw new Exception("Offer not found");
            }
            var product2 = await productRepository.FindByIdAsync(command.ProductOwnerId);
            var product1 = await productRepository.FindByIdAsync(command.ProductExchangeId);
            if(product1 == null || product2 == null)
            {
                throw new Exception("Product not found");
            }
            //validate available product
            if(product1.Available == false  || product2.Available == false)
            {
                throw new Exception("Product not available");
            }
            offer.Update(command);
            await unitOfWork.CompleteAsync();
            return offer;
        }
        catch(Exception e)
        {
            Console.WriteLine($"An error occurred while updating the offer: {e.Message}");
            return null;
        }
    }
}