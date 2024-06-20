using Backend.Donation.Domain.Model.Commnads.Ong;
using Backend.Donation.Domain.Model.Queries.Category;
using Backend.Donation.Domain.Model.Queries.Ong;
using Backend.Donation.Domain.Services;
using Backend.Donation.Interfaces.REST.Resources;
using Backend.Donation.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Backend.Donation.Domain.Model.Commnads;
using Backend.Donation.Domain.Model.Queries;

namespace Backend.Donation.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]

public class OngController(IOngCommandService ongCommandService,IOngQueryService ongQueryService) : ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> CreateOng(CreateOngResource resource)
    {
        var createOngCommand = CreateOngCommandFromResourceAssembler.ToCommandFromResource(resource);
        var ong = await ongCommandService.Handle(createOngCommand);
        if (ong is null) return BadRequest();
        var ongResource = OngResourceFormEntityAssembler.ToResourceFromEntiry(ong);
        return CreatedAtAction(nameof(GetOngById), new {ongId = ongResource.Id}, ongResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllOngs()
    {
        var getAllOngsQuery = new GetAllOngsQuery();
        var ongs = await ongQueryService.Handle(getAllOngsQuery);
        var ongResources = ongs.Select(OngResourceFormEntityAssembler.ToResourceFromEntiry);
        return Ok(ongResources);
    }
    
    [HttpGet("{ongId:int}")]
    public async Task<IActionResult> GetOngById(int ongId)
    {
        var getOngByIdQuery = new GetOngByIdQuery(ongId);
        var ong = await ongQueryService.Handle(getOngByIdQuery);
        if (ong == null) return NotFound();
        var ongResource = OngResourceFormEntityAssembler.ToResourceFromEntiry(ong);
        return Ok(ongResource);
    }
    
    [HttpGet("byWordAddress/{wordAddress}")]
    public async Task<IActionResult> GetAllOngByWordAddress(string wordAddress)
    {
        var getAllOngByWordAddress = new GetAllOngByWordAddress(wordAddress);
        var ongs = await ongQueryService.Handle(getAllOngByWordAddress);
        var ongResources = ongs.Select(OngResourceFormEntityAssembler.ToResourceFromEntiry);
        return Ok(ongResources);
    }
    
    [HttpGet("byWordName/{wordName}")]
    public async Task<IActionResult> GetAllOngByWordName(string wordName)
    {
        var getAllOngByWordName = new GetAllOngByWordName(wordName);
        var ongs = await ongQueryService.Handle(getAllOngByWordName);
        var ongResources = ongs.Select(OngResourceFormEntityAssembler.ToResourceFromEntiry);
        return Ok(ongResources);
    }
    
    [HttpGet("byCategory/{categoryId}")]
    public async Task<IActionResult> GetAllOngByCategory(int categoryId)
    {
        var getAllOngByCategory = new GetAllOngByCategory(categoryId);
        var ongs = await ongQueryService.Handle(getAllOngByCategory);
        var ongResources = ongs.Select(OngResourceFormEntityAssembler.ToResourceFromEntiry);
        return Ok(ongResources);
    }
    
    [HttpDelete("{ongId:int}")]
    public async Task<IActionResult> DeleteOng(int ongId)
    {
        var deleteOngCommand = new DeleteOngCommand(ongId);
        var ong = await ongCommandService.Handle(deleteOngCommand);
        if (ong == null) return NotFound();
        var ongResource = OngResourceFormEntityAssembler.ToResourceFromEntiry(ong);
        return Ok(ongResource);
    }
    
    [HttpPut("{ongId:int}")]
    public async Task<IActionResult> UpdateOng(int ongId, CreateOngResource resource)
    {
        var updateOngCommand = new UpdateOngCommand(ongId, resource.Name, resource.Type, resource.AboutUs,
            resource.MissionVision, resource.SupportForm, resource.Address, resource.Email, resource.Number,
            resource.UrlLogo, resource.UrlWebSite, resource.AttentionSchedule,resource.CategoryId);
        
        var ong = await ongCommandService.Handle(updateOngCommand);
        if (ong == null) return NotFound();
        var ongResource = OngResourceFormEntityAssembler.ToResourceFromEntiry(ong);
        return Ok(ongResource);
    }
}