using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Backend.Exchange.Domain.Model.Commnads.OfferCommands;
using Backend.Profiles.Domain.Model.Aggregates;

namespace Backend.Exchange.Domain.Model.Aggregates;

public partial class Offer
{
    public int Id { get; set; }
    public int ProductOwnerId { get; set; }
    public int ProductExchangeId { get; set; }
    public string State { get; set; }

    public Product ProductOwner { get; set; }
    public Product ProductExchange { get; set; }
    
    [JsonIgnore]
    public ICollection<Review> Reviews { get;internal set; }

    public Offer()
    {

    }

    public Offer(int productOwnerId, int productExchangeId, string state)
    {
        ProductOwnerId = productOwnerId;
        ProductExchangeId = productExchangeId;
        State = state;
    }

    public Offer(CreateOfferCommand command)
    {
        ProductOwnerId = command.ProductOwnerId;
        ProductExchangeId = command.ProductExchangeId;
        State = command.State;
    }

    public void Update(UpdateOfferCommand command)
    {
        ProductOwnerId = command.ProductOwnerId;               
        ProductExchangeId = command.ProductExchangeId;         
        State = command.State;                                 
    }





}