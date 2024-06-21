using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Commnads.DistrictCommands;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Application.Internal.CommandServices;

public class DistrictCommandService(IDistrictRepository districtRepository,IUnitOfWork unitOfWork) : IDistrictCommandService
{
    public async Task<District> Handle(CreateDistrictCommand command)
    {
        try
        {
            var districtExist = await districtRepository.GetByNameAsync(command.Name);
            if(districtExist != null)
            {
                throw new Exception("District already exists");
            }
            var district = new District(command);
            await districtRepository.AddAsync(district);
            await unitOfWork.CompleteAsync();
            return district;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the district: {e.Message}");
            return null;
        }
    }
    
    public async Task<District> Handle(UpdateDistrictCommand command)
    {
        var district = await districtRepository.FindByIdAsync(command.Id);
        if(district == null)
        {
            throw new Exception("District not found");
        }
        var districtExist = await districtRepository.GetByNameAsync(command.Name);
        if(districtExist != null && districtExist.Id != command.Id)
        {
            throw new Exception("District already exists");
        }
        district.Update(command);
        districtRepository.Update(district);
        await unitOfWork.CompleteAsync();
        return district;
    }
    
    public async Task<District> Handle(DeleteDistrictCommand command)
    {
        var district = await districtRepository.FindByIdAsync(command.Id);
        if(district == null)
        {
            throw new Exception("District not found");
        }
        districtRepository.Remove(district);
        await unitOfWork.CompleteAsync();
        return district;
    }
}