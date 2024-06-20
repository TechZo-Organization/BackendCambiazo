using Backend.Donation.Domain.Model.Commnads.Category;
using Backend.Donation.Domain.Model.Enitities;
using Backend.Donation.Domain.Repositories;
using Backend.Donation.Domain.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Donation.Domain.Model.Commnads;

namespace Backend.Donation.Application.Internal.CommandServices;

public class CategoryCommandService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : ICategoryCommandService
{
    public async Task<Category> Handle(CreateCategoryCommand command)
    {
        
        try
        {
            var existCategoryName = await categoryRepository.FindByName(command.Name);
            if(existCategoryName != null)
            {
                throw new Exception("Category name already exists");
            }
            
            var category = new Category(command);
            await categoryRepository.AddAsync(category);
            await unitOfWork.CompleteAsync();
            return category;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the category: {e.Message}");
            return null;
        }
    }
    
    public async Task<Category> Handle(DeleteCategoryCommand command)
    {
        try
        {
            var category = await categoryRepository.FindByIdAsync(command.Id);
            if(category == null)
            {
                throw new Exception("Category not found");
            }
            
            categoryRepository.Remove(category);
            await unitOfWork.CompleteAsync();
            return category;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the category: {e.Message}");
            return null;
        }
    }
    
    public async Task<Category> Handle(UpdateCategoryCommand command)
    {
        try
        {
            var category = await categoryRepository.FindByIdAsync(command.Id);
            if(category == null)
            {
                throw new Exception("Category not found");
            }
            var existCategoryName = await categoryRepository.FindByName(command.Name);
            if(existCategoryName != null)
            {
                throw new Exception("Category name already exists");
            }
            
            category.Update(command);
            await unitOfWork.CompleteAsync();
            return category;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the category: {e.Message}");
            return null;
        }
    }
    
    

}