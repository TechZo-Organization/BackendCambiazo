using System.Text.Json.Serialization;
using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Commnads.ProductCategoryCommmands;

namespace Backend.Exchange.Domain.Model.Enitities;

public class ProductCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public ICollection<Product> Products { get; set; }
    
    public ProductCategory()
    {
   
    }
    
    public ProductCategory( string name)
    {
        Name = name;
    }

    public ProductCategory(CreateProductCategoryCommand command)
    {
        Name = command.Name;
    }
   

    public void Update(UpdateProductCategoryCommand command)
    {
        Name = command.Name;
    }
}