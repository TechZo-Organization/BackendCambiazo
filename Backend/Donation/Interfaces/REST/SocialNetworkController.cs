using Backend.Donation.Domain.Model.Commnads.SocialNetwork;
using Backend.Donation.Domain.Services;
using Backend.Donation.Interfaces.REST.Resources.SocialNetwork;
using Backend.Donation.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Donation.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class SocialNetworkController(ISocialNetworkCommandService socialNetworkCommandService) : ControllerBase
{
        
        [HttpPost]
        public async Task<IActionResult> CreateSocialNetwork(CreateSocialNetworkResource resource)
        {
            var createSocialNetworkCommand = CreateSocialNetworkCommandFromResourceAssembler.ToCommandFromResource(resource);
            var socialNetwork = await socialNetworkCommandService.Handle(createSocialNetworkCommand);
            if (socialNetwork is null) return BadRequest();
            var socialNetworkResource = ResourceSocialNetworkFromEntityAssembler.ToResourceFromEntity(socialNetwork);
            //return CreatedAtAction(nameof(GetSocialNetworkById), new {socialNetworkId = socialNetworkResource.Id}, socialNetworkResource);
            return Ok(socialNetworkResource);
        }
        
        
        [HttpPut]
        public async Task<IActionResult> UpdateSocialNetwork(int socialNetworkId, CreateSocialNetworkResource resource)
        {
            var updateSocialNetworkCommand = new UpdateSocialNetworkCommand(socialNetworkId, resource.Name, resource.Url, resource.Icon,resource.OngId);
            var socialNetwork = await socialNetworkCommandService.Handle(updateSocialNetworkCommand);
            if (socialNetwork == null) return NotFound();
            var socialNetworkResource = ResourceSocialNetworkFromEntityAssembler.ToResourceFromEntity(socialNetwork);
            return Ok(socialNetworkResource);
        }
        
        [HttpDelete("{socialNetworkId:int}")]
        public async Task<IActionResult> DeleteSocialNetwork(int socialNetworkId)
        {
            var deleteSocialNetworkCommand = new DeleteSocialNetworkCommand(socialNetworkId);
            var socialNetwork = await socialNetworkCommandService.Handle(deleteSocialNetworkCommand);
            if (socialNetwork == null) return NotFound();
            var socialNetworkResource = ResourceSocialNetworkFromEntityAssembler.ToResourceFromEntity(socialNetwork);
            return Ok(socialNetworkResource);
        }
    
}