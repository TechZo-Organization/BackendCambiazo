using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Model.Commnads.SocialNetwork;
using Backend.Donation.Domain.Repositories;
using Backend.Donation.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Donation.Application.Internal.CommandServices;

public class SocialNetworkCommandService(ISocialNetworkRepository socialNetworkRepository, IOngRepository ongRepository, IUnitOfWork unitOfWork) : ISocialNetworkCommandService
{
   
   
   public async Task<SocialNetwork> Handle(CreateSocialNetworkCommand command)
   {
       try
       {
           var ong = await ongRepository.FindByIdAsync(command.OngId);
           if(ong == null)
           {
               throw new Exception("Ong not found");
           }
           var socialNetwork = new SocialNetwork(command);
           await socialNetworkRepository.AddAsync(socialNetwork);
           await unitOfWork.CompleteAsync();
           return socialNetwork;
       }
       catch (Exception e)
       {
           Console.WriteLine($"An error occurred while creating the social network: {e.Message}");
           return null;
       }
   }
   
   public async Task<SocialNetwork> Handle(UpdateSocialNetworkCommand command)
   {
       try
       {
           var socialNetwork = await socialNetworkRepository.FindByIdAsync(command.Id);
           if(socialNetwork == null)
           {
               throw new Exception("Social network not found");
           }
           var ong = await ongRepository.FindByIdAsync(command.OngId);
           if(ong == null)
           {
               throw new Exception("Ong not found");
           }
           
           socialNetwork.Update(command);
           await unitOfWork.CompleteAsync();
           return socialNetwork;
       }
       catch (Exception e)
       {
           Console.WriteLine($"An error occurred while updating the social network: {e.Message}");
           return null;
       }
   }
   
   public async Task<SocialNetwork> Handle(DeleteSocialNetworkCommand command)
   {
       try
       {
           var socialNetwork = await socialNetworkRepository.FindByIdAsync(command.Id);
           if(socialNetwork == null)
           {
               throw new Exception("Social network not found");
           }
           
           socialNetworkRepository.Remove(socialNetwork);
           await unitOfWork.CompleteAsync();
           return socialNetwork;
       }
       catch (Exception e)
       {
           Console.WriteLine($"An error occurred while deleting the social network: {e.Message}");
           return null;
       }
   }
   
   
   
   
}