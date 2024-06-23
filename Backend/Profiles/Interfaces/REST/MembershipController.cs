using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Backend.Profiles.Domain.Model.Commands.MembershipCommands;
using Backend.Profiles.Domain.Model.Queries.MembershipQueries;
using Backend.Profiles.Domain.Services;
using Backend.Profiles.Interfaces.REST.Resources;
using Backend.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class MembershipController(IMembershipCommandService membershipCommandService,IMembershipQueryService membershipQueryService): ControllerBase
{
    
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllMemberships()
    {
        var getAllMembershipsQuery = new GetAllMembershipsQuery();
        var memberships = await membershipQueryService.Handle(getAllMembershipsQuery);
        var membershipResources = memberships.Select(MembershipResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(membershipResources);
    }
    
    [HttpPost]
    [AllowAnonymous]

    public async Task<IActionResult> CreateMembership(CreateMembershipResource resource)
    {
        var createMembershipCommand = CreateMembershipCommandFromResourceAssembler.ToCommandFromResource(resource);
        var membership = await membershipCommandService.Handle(createMembershipCommand);
        if (membership is null) return BadRequest();
        var membershipResource = MembershipResourceFromEntityAssembler.ToResourceFromEntity(membership);
        //return CreatedAtAction(nameof(GetMembershipById), new { membershipId = membershipResource.Id }, membershipResource);
        return Ok(membershipResource);
    }
    
    [HttpPut("{membershipId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateMembership(int membershipId, CreateMembershipResource resource)
    {
        var updateMembershipCommand = new UpdateMembershipCommand(membershipId, resource.Name, resource.Description, resource.Price);
        var membership = await membershipCommandService.Handle(updateMembershipCommand);
        if (membership is null) return BadRequest();
        var membershipResource = MembershipResourceFromEntityAssembler.ToResourceFromEntity(membership);
        return Ok(membershipResource);
    }
    
    [HttpDelete("{membershipId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteMembership(int membershipId)
    {
        var deleteMembershipCommand = new DeleteMembershipCommand(membershipId);
        var membership = await membershipCommandService.Handle(deleteMembershipCommand);
        if (membership is null) return NotFound();
        var membershipResource = MembershipResourceFromEntityAssembler.ToResourceFromEntity(membership);
        return Ok(membershipResource);
    }
    
}