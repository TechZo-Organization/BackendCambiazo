namespace Backend.Donation.Domain.Model.Commnads.AccountNumber;

public record UpdateAccountNumberCommand(
        int Id,
        string Name,
        string CCI,
        string Number,
        int OngId
    );