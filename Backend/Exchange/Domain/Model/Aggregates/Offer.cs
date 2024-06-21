using System.ComponentModel.DataAnnotations.Schema;
using Backend.Exchange.Domain.Model.ValueObjects;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Backend.Exchange.Domain.Model.Aggregates;

public partial class Offer
{
   public int Id { get; set; }
   public int ProductOwnerId { get; set; }
   public int ProductExchangeId { get; set; }
   public OfferState State { get; set; }

   public Product ProductOwner { get; set; }
   public Product ProductExchange { get; set; }
   
   public Offer()
   {
       
   }
   
   public Offer(int productOwnerId, int productExchangeId, OfferState state)
   {
       ProductOwnerId = productOwnerId;
       ProductExchangeId = productExchangeId;
       State = state;
   }
   
   
   
}