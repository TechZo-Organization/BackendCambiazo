using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Model.Commnads.Ong;
using Backend.Donation.Domain.Repositories;
using Backend.Donation.Domain.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Donation.Domain.Model.Commnads;

namespace Backend.Donation.Application.Internal.CommandServices;

public class OngCommandService(IOngRepository ongRepository,ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : IOngCommandService
{
    public async Task<Ong> Handle(CreateOngCommand command)
    {
        try
        {
            var ong = new Ong(command);
            var existCategory = await categoryRepository.FindByIdAsync(command.CategoryId);
            
            if(existCategory == null)
            {
                throw new Exception("Category not found");
            }
            
            await ongRepository.AddAsync(ong);
            await unitOfWork.CompleteAsync();
            return ong;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the ong: {e.Message}");
            return null;
        }
    }
    
    
    public async Task<Ong> Handle(UpdateOngCommand command)
    {
        try
        {
            var ong = await ongRepository.FindByIdAsync(command.Id);
            
            if(ong == null)
            {
                throw new Exception("Ong not found");
            }
            
            ong.Update(command);
            ongRepository.Update(ong);
            await unitOfWork.CompleteAsync();
            return ong;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the ong: {e.Message}");
            return null;
        }
    }
    
    public async Task<Ong> Handle(DeleteOngCommand command)
    {
        try
        {
            var ong = await ongRepository.FindByIdAsync(command.Id);
            
            if(ong == null)
            {
                throw new Exception("Ong not found");
            }
            
            ongRepository.Remove(ong);
            await unitOfWork.CompleteAsync();
            return ong;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the ong: {e.Message}");
            return null;
        }
    }
}