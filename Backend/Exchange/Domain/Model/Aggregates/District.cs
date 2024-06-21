using Backend.Exchange.Domain.Model.Commnads.DistrictCommands;

namespace Backend.Exchange.Domain.Model.Aggregates;

public class District
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    
    public Department Department { get; set; }
    
    public District()
    {
        
    }
    
    public District(string name,int departmentId)
    {
        Name = name;
        DepartmentId = departmentId;
    }
    
    public District(CreateDistrictCommand command)
    {
        Name = command.Name;
        DepartmentId = command.DepartmentId;
        
    }
    
    public void Update(UpdateDistrictCommand command)
    {
        Name = command.Name;
        DepartmentId = command.DepartmentId;
    }
}