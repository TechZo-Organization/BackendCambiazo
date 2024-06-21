using Backend.Exchange.Domain.Model.Commnads.CountryCommands;
using Backend.Exchange.Domain.Model.Enitities;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Application.Internal.CommandServices;

public class CountryCommandService(ICountryRepository countryRepository,IUnitOfWork unitOfWork) : ICountryCommandService
{
    
    public async Task<Country> Handle(CreateCountryCommand command)
    {
        try
        {
            var countryExist = await countryRepository.GetByNameAsync(command.Name);
            if(countryExist != null)
            {
                throw new Exception("Country already exists");
            }
            var country = new Country(command);
            await countryRepository.AddAsync(country);
            await unitOfWork.CompleteAsync();
            return country;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the country: {e.Message}");
            return null;
        }
    }
    
    public async Task<Country> Handle(UpdateCountryCommand command)
    {
        try
        {
            var country = await countryRepository.FindByIdAsync(command.Id);
            if(country == null)
            {
                throw new Exception("Country not found");
            }
            var countryExist = await countryRepository.GetByNameAsync(command.Name);
            if(countryExist != null && countryExist.Id != command.Id)
            {
                throw new Exception("Country already exists");
            }
            country.Update(command);
            countryRepository.Update(country);
            await unitOfWork.CompleteAsync();
            return country;
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the country: {e.Message}");
            return null;
        }
    }
    
    public async Task<Country> Handle(DeleteCountryCommand command)
    {
        try
        {
            var country = await countryRepository.FindByIdAsync(command.Id);
            if(country == null)
            {
                throw new Exception("Country not found");
            }
            countryRepository.Remove(country);
            await unitOfWork.CompleteAsync();
            return country;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the country: {e.Message}");
            return null;
        }
    }
    
}