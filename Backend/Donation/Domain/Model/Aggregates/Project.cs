using Backend.Donation.Domain.Model.Commnads.Project;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;

namespace Backend.Donation.Domain.Model.Aggregates;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int OngId {internal get; set; }
    
    public Ong Ong {internal get; set; }
    
    public Project(string name, string description, int ongId)
    {
        Name = name;
        Description = description;
        OngId = ongId;
    }
    
    public Project()
    {
    }
    
    public Project(CreateProjectCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        OngId = command.OngId;
    }

    public void Update(UpdateProjectCommand command)
    {
        Id = command.Id;
        Name = command.Name;
        Description = command.Description;
        OngId = command.OngId;
    }
    
    
    
    
    
}