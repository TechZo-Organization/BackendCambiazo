using System.Collections;
using System.Text.Json.Serialization;
using Backend.Exchange.Domain.Model.Commnads.DepartmentCommands;
using Backend.Exchange.Domain.Model.Enitities;

namespace Backend.Exchange.Domain.Model.Aggregates;

public class Department
{
    public int Id { internal get; set; }
    public string Name { get; set; }
    
    public int CountryId { internal get; set; }
    public Country Country { internal get; set; }
    
    [JsonIgnore]
    public IEnumerable<District> Districts { get; internal set; }
    
    public List<string> Cities => Districts.Select(x => x.Name).ToList();
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