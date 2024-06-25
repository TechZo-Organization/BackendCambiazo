using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Backend.Profiles.Domain.Model.Commands.BenefitCommands;
using Backend.Profiles.Domain.Services;
using Backend.Profiles.Interfaces.REST.Resources;
using Backend.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class BenefitController(IBenefitCommandService benefitCommandService): ControllerBase
{
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateBenefit(CreateBenefitResource resource)
    {
        var createBenefitCommand = CreateBenefitCommandFromResourceAssembler.ToCommandFromResource(resource);
        var benefit = await benefitCommandService.Handle(createBenefitCommand);
        if (benefit is null) return BadRequest();
        var benefitResource = BenefitResourceFromEntityAssembler.ToResourceFromEntity(benefit);
        //return CreatedAtAction(nameof(GetBenefitById), new { benefitId = benefitResource.Id }, benefitResource);
        return Ok(benefitResource);
    }
    
    [HttpPut("{benefitId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateBenefit(int benefitId, CreateBenefitResource resource)
    {
        var updateBenefitCommand = new UpdateBenefitCommand(benefitId, resource.Description, resource.MembershipId);
        var benefit = await benefitCommandService.Handle(updateBenefitCommand);
        if (benefit is null) return BadRequest();
        var benefitResource = BenefitResourceFromEntityAssembler.ToResourceFromEntity(benefit);
        return Ok(benefitResource);
    }
    
    [HttpDelete("{benefitId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteBenefit(int benefitId)
    {
        var deleteBenefitCommand = new DeleteBenefitCommand(benefitId);
        var benefit = await benefitCommandService.Handle(deleteBenefitCommand);
        if (benefit is null) return NotFound();
        var benefitResource = BenefitResourceFromEntityAssembler.ToResourceFromEntity(benefit);
        return Ok(benefitResource);
    }
    
    
}