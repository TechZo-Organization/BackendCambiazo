namespace Backend.Donation.Interfaces.REST.Resources.AccountNumber;

public record CreateAccountNumberResource(
        string Name, 
        string CCI, 
        string Number, 
        int OngId
    );
