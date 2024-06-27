
using Backend.Exchange.Domain.Model.Commnads.ProductCommands;
using Backend.Exchange.Domain.Model.Queries.FavoriteProductQueries;
using Backend.Exchange.Domain.Model.Queries.ProductQueries;
using Backend.Exchange.Domain.Services;
using Backend.Exchange.Interfaces.REST.Resources;
using Backend.Exchange.Interfaces.REST.Transform;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Exchange.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController(IProductQueryService productQueryService,IProductCommandService productCommandService) : ControllerBase
{
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllProducts()
    {
        var getAllProductsQuery = new GetAllProductsQuery();
        var products = await productQueryService.Handle(getAllProductsQuery);
        var productResources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(productResources);
    }
    
    [HttpGet("{productId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetProductById(int productId)
    {
        var getProductByIdQuery = new GetProductByIdQuery(productId);
        var product = await productQueryService.Handle(getProductByIdQuery);
        if (product == null) return NotFound();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(productResource);
    }
    
   [HttpGet("boost/{boost:bool}")]
   [AllowAnonymous]
   public async Task<IActionResult> GetAllAvailableProductsByBoost(bool boost)
   {
         var getAllAvailableProductsByBoostQuery = new GetAllAvailableProductsByBoostQuery(boost);
         var products = await productQueryService.Handle(getAllAvailableProductsByBoostQuery);
         var productResources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
         return Ok(productResources);
   }
   
   
   //get by category:
    [HttpGet("category/{categoryId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAvailableProductsByCategory(int categoryId)
    {
        var getAllAvailableProductsByCategoryQuery = new GetAllAvailableProductsByCategoryIdQuery(categoryId);
        var products = await productQueryService.Handle(getAllAvailableProductsByCategoryQuery);
        var productResources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(productResources);
    }
    
    //get by word name:
    [HttpGet("name/{name}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAvailableProductsByName(string name)
    {
        var getAllAvailableProductsByNameQuery = new GetAllAvailableProductsByWordNameQuery(name);
        var products = await productQueryService.Handle(getAllAvailableProductsByNameQuery);
        var productResources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(productResources);
    }
    
    //by user adn aviable, 2 parameters:
    [HttpGet("user/{userId:int}/available/{available:bool}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAvailableProductsByUserAndAvailable(int userId, bool available)
    {
        var getAllAvailableProductsByUserAndAvailableQuery = new GetAllProductsByUserAndAvailableQuery(userId, available);
        var products = await productQueryService.Handle(getAllAvailableProductsByUserAndAvailableQuery);
        var productResources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(productResources);
    }
    
    //by price, district, word name and category:
    [HttpGet("price/{minPrice:float}/{maxPrice:float}/district/{districtId:int}/name/{name}/category/{categoryId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAvailableProductsByBetweenPricesAndDistrictAndWordNameAndCategory(int minPrice, int maxPrice, int districtId, string name, int categoryId)
    {
        var getAllAvailableProductsByBetweenPricesAndDistrictAndWordNameAndCategoryQuery = 
            new GetAllAvailableProductsByBetweenPricesAndDistrictAndWordNameAndCategoryQuery(minPrice, maxPrice, districtId, name, categoryId);
        
        var products = await productQueryService.Handle(getAllAvailableProductsByBetweenPricesAndDistrictAndWordNameAndCategoryQuery);
        var productResources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(productResources);
    }
    
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateProduct(CreateProductResource resource)
    {
        var createProductCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var product = await productCommandService.Handle(createProductCommand);
        if (product is null) return BadRequest();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(GetProductById), new {productId = productResource.Id}, productResource);
    }
    
    
    [HttpPut("{productId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateProduct(int productId, CreateProductResource resource)
    {
        var updateProductCommand = new UpdateProductCommand(productId, resource.Name, resource.Description,
            resource.ObjectChange, resource.Price, resource.Photo, resource.Boost, resource.Available,
            resource.CategoryId, resource.UserId, resource.DistrictId);
        
        var product = await productCommandService.Handle(updateProductCommand);
        if (product is null) return NotFound();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(productResource);
    }
    
    [HttpDelete("{productId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteProduct(int productId)
    {
        var deleteProductCommand = new DeleteProductCommand(productId);
        var product = await productCommandService.Handle(deleteProductCommand);
        if (product is null) return NotFound();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(productResource);
    }
    
    
}