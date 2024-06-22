using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.Commands.BenefitCommands;
using Backend.Profiles.Domain.Repositories;
using Backend.Profiles.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Profiles.Application.Internal.CommandServices;

public class BenefitCommandService(IMembershipRepository repository,IBenefitRepository benefitRepository,IUnitOfWork unitOfWork): IBenefitCommandService
{
    
    public async Task<Benefit> Handle(CreateBenefitCommand command)
    {
        try
        {
            
            //exist membership
            var membership = await repository.FindByIdAsync(command.MembershipId);
            if (membership == null)
            {
                throw new Exception("Membership not found");
            }
            var benefit = new Benefit(command);
            await benefitRepository.AddAsync(benefit);
            await unitOfWork.CompleteAsync();
            return benefit;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the benefit: {e.Message}");
            return null;
        }
    }
    
    public async Task<Benefit> Handle(UpdateBenefitCommand command)
    {
        try
        {
            
            var benefit = await benefitRepository.FindByIdAsync(command.Id);
            if (benefit == null)
            {
                throw new Exception("Benefit not found");
            }
            //exist membership
            var membership = await repository.FindByIdAsync(command.MembershipId);
            if (membership == null)
            {
                throw new Exception("Membership not found");
            }
            benefit.Update(command);
            await unitOfWork.CompleteAsync();
            return benefit;
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the benefit: {e.Message}");
            return null;
        }
    }
    
    public async Task<Benefit> Handle(DeleteBenefitCommand command)
    {
        try
        {
            var benefit = await benefitRepository.FindByIdAsync(command.Id);
            if (benefit == null)
            {
                throw new Exception("Benefit not found");
            }
            
            benefitRepository.Remove(benefit);
            await unitOfWork.CompleteAsync();
            return benefit;
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the benefit: {e.Message}");
            return null;
        }
    }
    
}