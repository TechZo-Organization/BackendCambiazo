namespace Backend.Donation.Interfaces.REST.Resources.AccountNumber;

public record AccountNumberResource(
    int Id, 
    string Name, 
    string CCI, 
    string Number, 
    int OngId
    );