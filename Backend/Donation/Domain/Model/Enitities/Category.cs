using System.Text.Json.Serialization;
using Backend.Donation.Domain.Model.Commnads.Category;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Model.Commnads;

namespace Backend.Donation.Domain.Model.Enitities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public ICollection<Ong> Ongs { get; internal set; }
    
    public Category()
    {
   
    }
    
    public Category( string name)
    {
        Name = name;
    }

    public Category(CreateCategoryCommand command)
    {
        Name = command.Name;
    }
   

    public void Update(UpdateCategoryCommand command)
    {
        Name = command.Name;
    }
    
    
    
}