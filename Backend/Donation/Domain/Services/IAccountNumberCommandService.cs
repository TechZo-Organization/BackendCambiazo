using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Model.Commnads.AccountNumber;

namespace Backend.Donation.Domain.Services;

public interface IAccountNumberCommandService
{
    Task<AccountNumber> Handle(CreateAccountNumberCommand command);
    Task<AccountNumber> Handle(UpdateAccountNumberCommand command);
    Task<AccountNumber> Handle(DeleteAccountNumberCommand command);
}