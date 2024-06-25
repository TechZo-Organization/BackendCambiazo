using Backend.Profiles.Domain.Model.Commands.MembershipCommands;
using Backend.Profiles.Domain.Model.Entities;
using Backend.Profiles.Domain.Repositories;
using Backend.Profiles.Domain.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Backend.Profiles.Application.Internal.CommandServices;

public class MembershipCommandService(IMembershipRepository repository,IUnitOfWork unitOfWork): IMembershipCommandService
{
    
    public async Task<Membership> Handle(CreateMembershipCommand command)
    {
        try
        {
            var membership = new Membership(command);
            await repository.AddAsync(membership);
            await unitOfWork.CompleteAsync();
            return membership;
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the membership: {e.Message}");
            return null;
        }
    }
    
    public async Task<Membership> Handle(UpdateMembershipCommand command)
    {
        try
        {
            var membership = await repository.FindByIdAsync(command.Id);
            if (membership == null)
            {
                throw new Exception("Membership not found");
            }
            membership.Update(command);
            await unitOfWork.CompleteAsync();
            return membership;
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the membership: {e.Message}");
            return null;
        }
    }
    
    public async Task<Membership> Handle(DeleteMembershipCommand command)
    {
        try
        {
            var membership = await repository.FindByIdAsync(command.Id);
            if (membership == null)
            {
                throw new Exception("Membership not found");
            }
            
            repository.Remove(membership);
            await unitOfWork.CompleteAsync();
            return membership;
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the membership: {e.Message}");
            return null;
        }
    }
}