namespace Backend.Donation.Domain.Model.Commnads.AccountNumber;

public record CreateAccountNumberCommand(
        string Name,
        string CCI,
        string Number,
        int OngId
    );