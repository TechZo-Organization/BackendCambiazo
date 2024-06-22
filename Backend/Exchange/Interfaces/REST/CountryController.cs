using Backend.Exchange.Domain.Model.Commnads.CountryCommands;
using Backend.Exchange.Domain.Services;
using Backend.Exchange.Interfaces.REST.Resources;
using Backend.Exchange.Interfaces.REST.Transform;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Exchange.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class CountryController(ICountryCommandService countryCommandService): ControllerBase
{
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateCountry(CreateCountryResource resource)
    {
        var createCountryCommand = CreateCountryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var country = await countryCommandService.Handle(createCountryCommand);
        if (country is null) return BadRequest();
        var countryResource = CountryResourceFromEntityAssembler.ToResourceFromEntity(country);
        //return CreatedAtAction(nameof(GetCountryById), new {countryId = countryResource.Id}, countryResource);
        return Ok(countryResource);
    }
    
    //put
    [HttpPut("{countryId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateCountry(int countryId, CreateCountryResource resource)
    {
        var updateCountryCommand = new UpdateCountryCommand(countryId, resource.Name);
        var country = await countryCommandService.Handle(updateCountryCommand);
        if (country == null) return NotFound();
        var countryResource = CountryResourceFromEntityAssembler.ToResourceFromEntity(country);
        return Ok(countryResource);
    }
    
    //delete
    [HttpDelete("{countryId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteCountry(int countryId)
    {
        var deleteCountryCommand = new DeleteCountryCommand(countryId);
        var country = await countryCommandService.Handle(deleteCountryCommand);
        if (country == null) return NotFound();
        var countryResource = CountryResourceFromEntityAssembler.ToResourceFromEntity(country);
        return Ok(countryResource);
    }
    
    
}