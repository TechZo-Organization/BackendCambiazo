using Backend.Exchange.Domain.Model.Commnads.DistrictCommands;
using Backend.Exchange.Domain.Model.Queries.DistrictQueries;
using Backend.Exchange.Domain.Services;
using Backend.Exchange.Interfaces.REST.Resources;
using Backend.Exchange.Interfaces.REST.Transform;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Exchange.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class DistrictController(IDistrictCommandService commandService,IDistrictQueryService districtQueryService): ControllerBase
{
    //post
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateDistrict(CreateDistrictResource resource)
    {
        var createDistrictCommand = CreateDistrictCommandFromResourceAssembler.ToCommandFromResource(resource);
        var district = await commandService.Handle(createDistrictCommand);
        if (district is null) return BadRequest();
        var districtResource = DistrictResourceFromEntityAssembler.ToResourceFromEntity(district);
        return CreatedAtAction(nameof(GetDistrictById), new {districtId = districtResource.Id}, districtResource);
    }
    
    //put
    [HttpPut("{districtId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateDistrict(int districtId, CreateDistrictResource resource)
    {
        var updateDistrictCommand = new UpdateDistrictCommand(districtId, resource.Name, resource.DepartmentId);
        var district = await commandService.Handle(updateDistrictCommand);
        if (district == null) return NotFound();
        var districtResource = DistrictResourceFromEntityAssembler.ToResourceFromEntity(district);
        return Ok(districtResource);
    }
    
    //delete
    [HttpDelete("{districtId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteDistrict(int districtId)
    {
        var deleteDistrictCommand = new DeleteDistrictCommand(districtId);
        var district = await commandService.Handle(deleteDistrictCommand);
        if (district == null) return NotFound();
        var districtResource = DistrictResourceFromEntityAssembler.ToResourceFromEntity(district);
        return Ok(districtResource);
    }
    
    [HttpGet("{districtId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetDistrictById(int districtId)
    {
        var getDistrictByIdQuery = new GetDistrictByIdQuery(districtId);
        var district = await districtQueryService.Handle(getDistrictByIdQuery);
        if (district == null) return NotFound();
        var districtResource = DistrictResourceFromEntityAssembler.ToResourceFromEntity(district);
        return Ok(districtResource);
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllDistricts()
    {
        var getAllDistrictsQuery = new GetAllDistrictsQuery();
        var districts = await districtQueryService.Handle(getAllDistrictsQuery);
        var districtResources = districts.Select(DistrictResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(districtResources);
    }
}