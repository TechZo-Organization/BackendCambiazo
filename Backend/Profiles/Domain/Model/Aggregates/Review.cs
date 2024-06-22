using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.Commands.ReviewCommands;

namespace Backend.Profiles.Domain.Model.Aggregates;

public partial class Review
{
    public int Id { get; set; }
    public string Message { get; set; }
    public string State { get; set; }
    
    public int ProfileAuthorId { get; set; }
    public int ProfileReceptorId { get; set; }
    public int OfferId { get; set; }
    
    public Profile UserAuthor { get; set; }
    public Profile UserReceptor { get; set; }
    public Offer Offer { get; set; }
    
    public Review(string message, string state, int profileAuthorId, int profileReceptorId, int offerId)
    {
        Message = message;
        State = state;
        ProfileAuthorId = profileAuthorId;
        ProfileReceptorId = profileReceptorId;
        OfferId = offerId;
    }
    
    public Review()
    {
        
    }
    
    public Review(CreateReviewCommand command)
    {
        Message = command.Message;
        State = command.State;
        ProfileAuthorId = command.UserAuthorId;
        ProfileReceptorId = command.UserReceptorId;
        OfferId = command.OfferId;
    }

}