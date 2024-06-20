using Backend.Exchange.Domain.Model.Commnads.ProductCategoryCommmands;
using Backend.Exchange.Domain.Model.Enitities;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Backend.Exchange.Application.Internal.CommandServices;

public class ProductCategoryCommandService(IProductCategoryRepository productCategoryRepository,IUnitOfWork unitOfWork) : IProductCategoryCommandService
{
    
    public async Task<ProductCategory> Handle(CreateProductCategoryCommand command)
    {
        try
        {
            var productCategoryExist = await productCategoryRepository.FindByName(command.Name);
            if(productCategoryExist != null)
            {
                throw new Exception("Product category already exists");
            }
            var productCategory = new ProductCategory(command);
            await productCategoryRepository.AddAsync(productCategory);
            await unitOfWork.CompleteAsync();
            return productCategory;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the product category: {e.Message}");
            return null;
        }
    }
    
    
    public async Task<ProductCategory> Handle(UpdateProductCategoryCommand command)
    {
        try
        {
            var productCategory = await productCategoryRepository.FindByIdAsync(command.Id);
            
            if(productCategory == null)
            {
                throw new Exception("Product category not found");
            }
            
            var productCategoryExist = await productCategoryRepository.FindByName(command.Name);
            if(productCategoryExist != null)
            {
                throw new Exception("Product category already exists");
            }
            
            productCategory.Update(command);
            productCategoryRepository.Update(productCategory);
            await unitOfWork.CompleteAsync();
            return productCategory;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the product category: {e.Message}");
            return null;
        }
    }
    
    public async Task<ProductCategory> Handle(DeleteProductCategoryCommand command)
    {
        try
        {
            var productCategory = await productCategoryRepository.FindByIdAsync(command.Id);
            
            if(productCategory == null)
            {
                throw new Exception("Product category not found");
            }
            
            productCategoryRepository.Remove(productCategory);
            await unitOfWork.CompleteAsync();
            return productCategory;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the product category: {e.Message}");
            return null;
        }
    }
    
}