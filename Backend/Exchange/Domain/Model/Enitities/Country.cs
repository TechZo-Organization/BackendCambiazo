using Backend.Exchange.Domain.Model.Commnads.CountryCommands;

namespace Backend.Exchange.Domain.Model.Enitities;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Country(string name)
    {
        Name = name;
    }
    
    public Country()
    {
        
    }
    
    public Country(CreateCountryCommand command)
    {
        Name = command.Name;
    }
    
    public void Update(UpdateCountryCommand command)
    {
        Name = command.Name;
    }
}