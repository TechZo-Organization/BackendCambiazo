using Backend.Donation.Domain.Model.Commnads.AccountNumber;

namespace Backend.Donation.Domain.Model.Aggregates;

public class AccountNumber
{
    public int Id { internal get; set; }
    public string Name { get; set; }
    public string CCI { get; set; }
    public string Number { get; set; }
    public int OngId {internal get; set; }
    
    public Ong Ong {internal get; set; }

    
    public AccountNumber(string name, string cci, string number, int ongId)
    {
        Name = name;
        CCI = cci;
        Number = number;
        OngId = ongId;
    }
    
    
    public AccountNumber()
    {
    }
    
    public AccountNumber(CreateAccountNumberCommand command)
    {
        Name = command.Name;
        CCI = command.CCI;
        Number = command.Number;
        OngId = command.OngId;
    }
    
    public void Update(UpdateAccountNumberCommand command)
    {
        Id = command.Id;
        Name = command.Name;
        CCI = command.CCI;
        Number = command.Number;
        OngId = command.OngId;
    }
}