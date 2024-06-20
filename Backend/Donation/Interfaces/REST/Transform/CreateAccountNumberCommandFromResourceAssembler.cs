using Backend.Donation.Domain.Model.Commnads.AccountNumber;
using Backend.Donation.Interfaces.REST.Resources.AccountNumber;

namespace Backend.Donation.Interfaces.REST.Transform;

public class CreateAccountNumberCommandFromResourceAssembler
{
    public static CreateAccountNumberCommand ToCommandFromResource(CreateAccountNumberResource resource)
    {
        return new CreateAccountNumberCommand(
            resource.Name,
            resource.CCI,
            resource.Number,
            resource.OngId
        );
    }
}