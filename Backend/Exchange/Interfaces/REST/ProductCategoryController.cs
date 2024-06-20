using Backend.Exchange.Application.Internal.CommandServices;
using Backend.Exchange.Application.Internal.QueryServices;
using Backend.Exchange.Domain.Model.Commnads.ProductCategoryCommmands;
using Backend.Exchange.Domain.Model.Queries.ProductCategoryQueries;
using Backend.Exchange.Interfaces.REST.Resources;
using Backend.Exchange.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Exchange.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductCategoryController(ProductCategoryCommandService productCategoryCommandService,ProductCategoryQueryService productCategoryQueryService) : ControllerBase
{
    /*?
      [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryResource resource)
    {
        var createCategoryCommand = CreateCategoryFromResourceAssembler.ToCommandFromResource(resource);
        var category = await categoryCommandService.Handle(createCategoryCommand);
        if (category is null) return BadRequest();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return CreatedAtAction(nameof(GetCategoryById), new {categoryId = categoryResource.Id}, categoryResource);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var getAllCategoriesQuery = new GetAllCategoriesQuery();
        var categories = await categoryQueryService.Handle(getAllCategoriesQuery);
        var categoryResources = categories.Select(CategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(categoryResources);
    }
    
    [HttpGet("{categoryId:int}")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var getCategoryByIdQuery = new GetCategoryByIdQuery(categoryId);
        var category = await categoryQueryService.Handle(getCategoryByIdQuery);
        if (category == null) return NotFound();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }
    
    [HttpDelete("{categoryId:int}")]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        var deleteCategoryCommand = new DeleteCategoryCommand(categoryId);
        var category = await categoryCommandService.Handle(deleteCategoryCommand);
        if (category == null) return NotFound();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }
    
    [HttpPut("{categoryId:int}")]
    public async Task<IActionResult> UpdateCategory(int categoryId, CreateCategoryResource resource)
    {
        var updateCategoryCommand = new UpdateCategoryCommand(categoryId, resource.Name);
        var category = await categoryCommandService.Handle(updateCategoryCommand);
        if (category == null) return NotFound();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }
     */
    
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