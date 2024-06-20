using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Interfaces.REST.Resources.AccountNumber;

namespace Backend.Donation.Interfaces.REST.Transform;

public class ResourceAccountNumberFromEntityAssembler
{
    public static AccountNumberResource ToResourceFromEntity(AccountNumber accountNumber)
    {
        return new AccountNumberResource(
            accountNumber.Id,
            accountNumber.Name,
            accountNumber.CCI,
            accountNumber.Number,
            accountNumber.OngId
        );
    }
}