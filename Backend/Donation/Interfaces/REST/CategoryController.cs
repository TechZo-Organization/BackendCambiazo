using Backend.Donation.Domain.Model.Commnads.Category;
using Backend.Donation.Domain.Model.Queries.Category;
using Backend.Donation.Domain.Services;
using Backend.Donation.Interfaces.REST.Resources;
using Backend.Donation.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;


namespace Backend.Donation.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoryController(ICategoryCommandService categoryCommandService,ICategoryQueryService categoryQueryService): ControllerBase
{
   
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateCategory(CreateCategoryResource resource)
    {
        var createCategoryCommand = CreateCategoryFromResourceAssembler.ToCommandFromResource(resource);
        var category = await categoryCommandService.Handle(createCategoryCommand);
        if (category is null) return BadRequest();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return CreatedAtAction(nameof(GetCategoryById), new {categoryId = categoryResource.Id}, categoryResource);
    }
    
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllCategories()
    {
        var getAllCategoriesQuery = new GetAllCategoriesQuery();
        var categories = await categoryQueryService.Handle(getAllCategoriesQuery);
        var categoryResources = categories.Select(CategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(categoryResources);
    }
    
    [HttpGet("{categoryId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var getCategoryByIdQuery = new GetCategoryByIdQuery(categoryId);
        var category = await categoryQueryService.Handle(getCategoryByIdQuery);
        if (category == null) return NotFound();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }
    
    [HttpDelete("{categoryId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        var deleteCategoryCommand = new DeleteCategoryCommand(categoryId);
        var category = await categoryCommandService.Handle(deleteCategoryCommand);
        if (category == null) return NotFound();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }
    
    [HttpPut("{categoryId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateCategory(int categoryId, CreateCategoryResource resource)
    {
        var updateCategoryCommand = new UpdateCategoryCommand(categoryId, resource.Name);
        var category = await categoryCommandService.Handle(updateCategoryCommand);
        if (category == null) return NotFound();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }
    
    
}