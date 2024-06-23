using Backend.Exchange.Domain.Model.Commnads.OfferCommands;
using Backend.Exchange.Domain.Model.Queries.OfferQueries;
using Backend.Exchange.Domain.Services;
using Backend.Exchange.Interfaces.REST.Resources;
using Backend.Exchange.Interfaces.REST.Transform;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Exchange.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class OfferController(IOfferCommandService offerCommandService,IOfferQueryService offerQueryService) : ControllerBase
{
    
  
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateOffer(CreateOfferResource resource)
    {
        var createOfferCommand = CreateOfferCommandFromResourceAssembler.ToCommandFromResource(resource);
        var offer = await offerCommandService.Handle(createOfferCommand);
        if (offer is null) return BadRequest();
        var offerResource = OfferResourceFromEntityAssembler.ToResourceFromEntity(offer);
        //return CreatedAtAction(nameof(GetOfferById), new {offerId = offerResource.Id}, offerResource);
        return Ok(offerResource);
    }
    
    [HttpPut("{offerId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateOffer(int offerId, CreateOfferResource resource)
    {
        var updateOfferCommand = new UpdateOfferCommand(offerId, resource.ProductOwnerId, resource.ProductExchangeId, resource.State);
        var offer = await offerCommandService.Handle(updateOfferCommand);
        if (offer == null) return NotFound();
        var offerResource = OfferResourceFromEntityAssembler.ToResourceFromEntity(offer);
        return Ok(offerResource);
    }
    
    [HttpDelete("{offerId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteOffer(int offerId)
    {
        var deleteOfferCommand = new DeleteOfferCommand(offerId);
        var offer = await offerCommandService.Handle(deleteOfferCommand);
        if (offer == null) return NotFound();
        var offerResource = OfferResourceFromEntityAssembler.ToResourceFromEntity(offer);
        return Ok(offerResource);
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllOffers()
    {
        var getAllOffersQuery = new GetAllOffersQuery();
        var offers = await offerQueryService.Handle(getAllOffersQuery);
        var offerResources = offers.Select(OfferResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(offerResources);
    }
    
}