using Backend.Exchange.Domain.Model.Commnads.DepartmentCommands;
using Backend.Exchange.Domain.Model.Enitities;

namespace Backend.Exchange.Domain.Model.Aggregates;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public int CountryId { get; set; }
    public Country Country { get; set; }
    
    public Department()
    {
        
    }
    
    public Department(string name,int countryId)
    {
        Name = name;
        CountryId = countryId;
    }
    public Department(CreateDepartmentCommand command)
    {
        Name = command.Name;
        CountryId = command.CountryId;
    }
    
    
    public void Update(UpdateDepartmentCommand command)
    {
        Name = command.Name;
        CountryId = command.CountryId;
    }
}