using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.Commands;
using Backend.Profiles.Domain.Repositories;
using Backend.Profiles.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
    
    public async Task<Profile?> Handle(UpdateProfileCommand command)
    {
        var profile = await profileRepository.FindByIdAsync(command.Id);
        if (profile == null)
        {
            Console.WriteLine($"Profile with id {command.Id} not found");
            return null;
        }
        
        profile.Update(command);
        try
        {
            await unitOfWork.CompleteAsync();
            return profile;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the profile: {e.Message}");
            return null;
        }
    }
    
    public async Task<Profile?> Handle(DeleteProfileCommand command)
    {
        var profile = await profileRepository.FindByIdAsync(command.Id);
        if (profile == null)
        {
            Console.WriteLine($"Profile with id {command.Id} not found");
            return null;
        }
        
        try
        {
            profileRepository.Remove(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the profile: {e.Message}");
            return null;
        }
    }
    
    
}