using Backend.Exchange.Domain.Model.Commnads.FavoriteProductcommands;
using Backend.Exchange.Domain.Model.Queries.FavoriteProductQueries;
using Backend.Exchange.Domain.Services;
using Backend.Exchange.Interfaces.REST.Resources;
using Backend.Exchange.Interfaces.REST.Transform;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Exchange.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
public class FavoriteProductController(IFavoriteProductCommandService favoriteProductCommandService,IProductFavoriteQueryService productFavoriteQueryService) : ControllerBase
{
    
  
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateFavoriteProduct(CreateFavoriteProductResource resource)
    {
        var createFavoriteProductCommand = CreateFavoriteProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var favoriteProduct = await favoriteProductCommandService.Handle(createFavoriteProductCommand);
        if (favoriteProduct is null) return BadRequest();
        var favoriteProductResource = FavoriteProductResourceFromEntityAssembler.ToResourceFromEntity(favoriteProduct);
        //return CreatedAtAction(nameof(GetOfferById), new {offerId = offerResource.Id}, offerResource);
        return Ok(favoriteProductResource);
    }
    
    [HttpDelete("{favoriteProductId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteFavoriteProduct(int favoriteProductId)
    {
        var deleteFavoriteProductCommand = new DeleteFavoriteProductCommand(favoriteProductId);
        var favoriteProduct = await favoriteProductCommandService.Handle(deleteFavoriteProductCommand);
        if (favoriteProduct == null) return NotFound();
        var favoriteProductResource = FavoriteProductResourceFromEntityAssembler.ToResourceFromEntity(favoriteProduct);
        return Ok(favoriteProductResource);
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllFavoriteProducts()
    {
        var getAllFavoriteProductsQuery = new GetAllFavoriteProductsQuery();
        var favoriteProducts = await productFavoriteQueryService.Handle(getAllFavoriteProductsQuery);
        var favoriteProductResources = favoriteProducts.Select(FavoriteProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(favoriteProductResources);
    }


    [HttpGet("user/{userId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllFavoriteProductsByUserId(int userId)
    {
        var getAllFavoriteProductsByUserId = new GetAllFavoriteProductsByUserIdQuery(userId);
        var favoriteProducts = await productFavoriteQueryService.Handle(getAllFavoriteProductsByUserId);
        var favoriteProductResources = favoriteProducts.Select(FavoriteProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(favoriteProductResources);
    }
}