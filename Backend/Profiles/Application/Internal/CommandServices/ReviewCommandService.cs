using Backend.Exchange.Domain.Repositories;
using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.Commands.ReviewCommands;
using Backend.Profiles.Domain.Repositories;
using Backend.Profiles.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Profiles.Application.Internal.CommandServices;

public class ReviewCommandService(IReviewRepository repository,IProfileRepository profileRepository,IOfferRepository offerRepository, IUnitOfWork unitOfWork): IReviewCommandService
{
    
   public async Task<Review> Handle(CreateReviewCommand command)
   {
       try
       {
            //exist profile for receptor and author
              var profileReceptor = await profileRepository.FindByIdAsync(command.UserReceptorId);
              var profileAuthor = await profileRepository.FindByIdAsync(command.UserAuthorId);
              if(profileReceptor == null || profileAuthor == null)
              {
                  throw new Exception("Profile not found");
              }
              //offer exist and state is accepted
              var offer = await offerRepository.FindByIdAsync(command.OfferId);
              
              if(offer == null)throw new Exception("Offer not found or state is not accepted");
              if (offer.State != "Accepted") throw new Exception("Offer not found or state is not accepted");
              
              //one review per offer in each offer
              var reviewExist = await repository.FindByAuthorIdAndReceptorIdAndOffer(command.UserAuthorId, command.UserReceptorId, command.OfferId);
              if (reviewExist != null)
              {
                  throw new Exception("This user already made a review for this offer");
              }
              
              var review = new Review(command);
              await repository.AddAsync(review);
              await unitOfWork.CompleteAsync();
              return review;
       }
       catch (Exception e)
       {
           throw new Exception(e.Message);
       }

   }
   
    public async Task<Review> Handle(DeleteReviewCommand command)
    {
        try
        {
            
         var review = await repository.FindByIdAsync(command.Id);
         if (review == null)
         {
              throw new Exception("Review not found");
         }
         repository.Remove(review);
         await unitOfWork.CompleteAsync();
         return review;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}