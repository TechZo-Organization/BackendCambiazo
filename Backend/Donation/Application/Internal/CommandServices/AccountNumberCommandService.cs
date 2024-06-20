using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Model.Commnads.AccountNumber;
using Backend.Donation.Domain.Repositories;
using Backend.Donation.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Donation.Application.Internal.CommandServices;

public class AccountNumberCommandService(IAccountNumberRepository accountNumberRepository, IOngRepository ongRepository,IUnitOfWork unitOfWork) : IAccountNumberCommandService
{
    
public async Task<AccountNumber> Handle(CreateAccountNumberCommand command)
    {
        try
        {
            var ong = await ongRepository.FindByIdAsync(command.OngId);
            if(ong == null)
            {
                throw new Exception("Ong not found");
            }
            var accountNumber = new AccountNumber(command);
            await accountNumberRepository.AddAsync(accountNumber);
            await unitOfWork.CompleteAsync();
            return accountNumber;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the account number: {e.Message}");
            return null;
        }
    }
    
    
    public async Task<AccountNumber> Handle(UpdateAccountNumberCommand command)
    {
        try
        {
            var accountNumber = await accountNumberRepository.FindByIdAsync(command.Id);
            
            if(accountNumber == null)
            {
                throw new Exception("Account number not found");
            }
            var ong = await ongRepository.FindByIdAsync(command.OngId);
            if(ong == null)
            {
                throw new Exception("Ong not found");
            }
            
            accountNumber.Update(command);
            accountNumberRepository.Update(accountNumber);
            await unitOfWork.CompleteAsync();
            return accountNumber;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the account number: {e.Message}");
            return null;
        }
    }
    
    public async Task<AccountNumber> Handle(DeleteAccountNumberCommand command)
    {
        try
        {
            var accountNumber = await accountNumberRepository.FindByIdAsync(command.Id);
            
            if(accountNumber == null)
            {
                throw new Exception("Account number not found");
            }
            
            accountNumberRepository.Remove(accountNumber);
            await unitOfWork.CompleteAsync();
            return accountNumber;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the account number: {e.Message}");
            return null;
        }
    }
    
}