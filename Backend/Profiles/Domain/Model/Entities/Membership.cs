using System.Text.Json.Serialization;
using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.Commands.MembershipCommands;

namespace Backend.Profiles.Domain.Model.Entities;

public class Membership
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    
    [JsonIgnore]
    public ICollection<Benefit> Benefits { get; internal set; }
    [JsonIgnore]
    public ICollection<Profile> Users { get;internal set; }
    
    public Membership()
    {
        
    }
    
    public Membership(string name, string description, float price)
    {
        Name = name;
        Description = description;
        Price = price;
    }
    
    public Membership(CreateMembershipCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Price = command.Price;
    }
    
    public void Update(UpdateMembershipCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Price = command.Price;
    }
    
    
}