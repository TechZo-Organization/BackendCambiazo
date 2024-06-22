using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Commnads.ProductCommands;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;
using Backend.Profiles.Domain.Repositories;
using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Backend.Exchange.Application.Internal.CommandServices;

public class ProductCommandService(
    IProductRepository productRepository,
    IDistrictRepository districtRepository,
    IProductCategoryRepository productCategoryRepository, 
    IProfileRepository profileRepository,
    IUnitOfWork unitOfWork): IProductCommandService 
{
    
    public async Task<Product> Handle(CreateProductCommand command)
    {
        try
        {
            //exist user
            var user = await profileRepository.FindByIdAsync(command.UserId);
            if(user == null)
            {
                throw new Exception("User not found");
            }
            //exist district
            var district = await districtRepository.FindByIdAsync(command.DistrictId);
            if(district == null)
            {
                throw new Exception("District not found");
            }
            //exist product category
            var productCategory = await productCategoryRepository.FindByIdAsync(command.CategoryId);
            if(productCategory == null)
            {
                throw new Exception("Product category not found");
            }
            
            var product = new Product(command);
            await productRepository.AddAsync(product);
            await unitOfWork.CompleteAsync();
            return product;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the product: {e.Message}");
            return null;
        }
    }

    public async Task<Product> Handle(UpdateProductCommand command)
    {
        try
        {

            //exist id
            var productExist = await productRepository.FindByIdAsync(command.Id);
            if (productExist == null)
            {
                throw new Exception("Product not found");
            }

            //exist user
            var user = await profileRepository.FindByIdAsync(command.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            //exist district
            var district = await districtRepository.FindByIdAsync(command.DistrictId);
            if (district == null)
            {
                throw new Exception("District not found");
            }

            //exist product category
            var productCategory = await productCategoryRepository.FindByIdAsync(command.CategoryId);
            if (productCategory == null)
            {
                throw new Exception("Product category not found");
            }

            var product = await productRepository.FindByIdAsync(command.Id);
            product.Update(command);
            productRepository.Update(product);
            await unitOfWork.CompleteAsync();
            return product;
        }
        catch(Exception e)
        {
            
            Console.WriteLine($"An error occurred while updating the product: {e.Message}");
            return null;
        }
    }

    public async Task<Product> Handle(DeleteProductCommand command)
    {
        try
        {
            //exist id
            var productExist = await productRepository.FindByIdAsync(command.Id);
            if (productExist == null)
            {
                throw new Exception("Product not found");
            }
            var product = await productRepository.FindByIdAsync(command.Id);
            productRepository.Remove(product);
            await unitOfWork.CompleteAsync();
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the product: {e.Message}");
            return null;
            
        }
    }
}