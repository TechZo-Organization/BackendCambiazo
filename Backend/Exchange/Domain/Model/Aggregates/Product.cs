using System.Collections;
using System.Text.Json.Serialization;
using Backend.Exchange.Domain.Model.Commnads.ProductCommands;
using Backend.Exchange.Domain.Model.Enitities;
using Backend.Profiles.Domain.Model.Aggregates;

namespace Backend.Exchange.Domain.Model.Aggregates;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ObjectChange { get; set; }
    public float Price { get; set; }
    public string Photo { get; set; }
    public bool Boost { get; set; }
    public bool Available { get; set; }
    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public int DistrictId { get; set; }
    
    public Profile User { get; set; }
    public ProductCategory Category { get; set; }
    public District District { get; set; }
    [JsonIgnore]
    public ICollection<Offer> OffersAsOwner { get; set; }
    [JsonIgnore]
    public ICollection<Offer> OffersAsExchange { get; set; }
    [JsonIgnore]
    public ICollection<FavoriteProduct> FavoriteProducts { get; set; }
    
    
    public Product(string name, string description, string objectChange, float price, string photo, bool boost, bool available, int categoryId,int userId, int districtId)
    {
        Name = name;
        Description = description;
        ObjectChange = objectChange;
        Price = price;
        Photo = photo;
        Boost = boost;
        Available = available;
        CategoryId = categoryId;
        UserId = userId;
        DistrictId = districtId;
    }
    public Product(CreateProductCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        ObjectChange = command.ObjectChange;
        Price = command.Price;
        Photo = command.Photo;
        Boost = command.Boost;
        Available = command.Available;
        CategoryId = command.CategoryId;
        UserId = command.UserId;
        DistrictId = command.DistrictId;
    }
     public void Update(UpdateProductCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        ObjectChange = command.ObjectChange;
        Price = command.Price;
        Photo = command.Photo;
        Boost = command.Boost;
        Available = command.Available;
        CategoryId = command.CategoryId;
        UserId = command.UserId;
        DistrictId = command.DistrictId;
    }
    
}