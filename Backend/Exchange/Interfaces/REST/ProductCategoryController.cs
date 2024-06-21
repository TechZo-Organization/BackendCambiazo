using Backend.Exchange.Application.Internal.CommandServices;
using Backend.Exchange.Application.Internal.QueryServices;
using Backend.Exchange.Domain.Model.Commnads.ProductCategoryCommmands;
using Backend.Exchange.Domain.Model.Queries.ProductCategoryQueries;
using Backend.Exchange.Domain.Services;
using Backend.Exchange.Interfaces.REST.Resources;
using Backend.Exchange.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Exchange.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductCategoryController(IProductCategoryCommandService productCategoryCommandService,IProductCategoryQueryService productCategoryQueryService) : ControllerBase
{
    
    
    [HttpPost]
    public async Task<IActionResult> CreateProductCategory(CreateProductCategoryResource resource)
    {
        var createProductCategoryCommand = CreateProductCategoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var productCategory = await productCategoryCommandService.Handle(createProductCategoryCommand);
        if (productCategory is null) return BadRequest();
        var productCategoryResource = ProductCategoryResourceFromEntityAssembler.ToResourceFromEntity(productCategory);
        return CreatedAtAction(nameof(GetProductCategoryById), new {productCategoryId = productCategoryResource.Id}, productCategoryResource);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAllProductCategories()
    {
        var getAllProductCategoriesQuery = new GetAllProductCategoriesQuery();
        var productCategories = await productCategoryQueryService.Handle(getAllProductCategoriesQuery);
        var productCategoryResources = productCategories.Select(ProductCategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(productCategoryResources);
    }
    
    [HttpGet("{productCategoryId:int}")]
    public async Task<IActionResult> GetProductCategoryById(int productCategoryId)
    {
        var getProductCategoryByIdQuery = new GetProductCategoryByIdQuery(productCategoryId);
        var productCategory = await productCategoryQueryService.Handle(getProductCategoryByIdQuery);
        if (productCategory == null) return NotFound();
        var productCategoryResource = ProductCategoryResourceFromEntityAssembler.ToResourceFromEntity(productCategory);
        return Ok(productCategoryResource);
    }
    
    [HttpDelete("{productCategoryId:int}")]
    public async Task<IActionResult> DeleteProductCategory(int productCategoryId)
    {
        var deleteProductCategoryCommand = new DeleteProductCategoryCommand(productCategoryId);
        var productCategory = await productCategoryCommandService.Handle(deleteProductCategoryCommand);
        if (productCategory == null) return NotFound();
        var productCategoryResource = ProductCategoryResourceFromEntityAssembler.ToResourceFromEntity(productCategory);
        return Ok(productCategoryResource);
    }
    
    
    [HttpPut("{productCategoryId:int}")]
    public async Task<IActionResult> UpdateProductCategory(int productCategoryId, CreateProductCategoryResource resource)
    {
        var updateProductCategoryCommand = new UpdateProductCategoryCommand(productCategoryId, resource.Name);
        var productCategory = await productCategoryCommandService.Handle(updateProductCategoryCommand);
        if (productCategory == null) return NotFound();
        var productCategoryResource = ProductCategoryResourceFromEntityAssembler.ToResourceFromEntity(productCategory);
        return Ok(productCategoryResource);
    }
   
       
}