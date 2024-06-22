using Backend.Donation.Domain.Model.Commnads.Project;
using Backend.Donation.Domain.Services;
using Backend.Donation.Interfaces.REST.Resources.Project;
using Backend.Donation.Interfaces.REST.Transform;
using Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Donation.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProjectController(IProjectCommandService projectCommandService) : ControllerBase
{
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateProject(CreateProjectResource resource)
    {
        var createProjectCommand = CreateProjectCommandFromResourceAssembler.ToCommandFromResource(resource);
        var project = await projectCommandService.Handle(createProjectCommand);
        if (project is null) return BadRequest();
        var projectResource = ResourceProjectFromEntityAssembler.ToResourceFromEntity(project);
        //return CreatedAtAction(nameof(GetProjectById), new {projectId = projectResource.Id}, projectResource);
        return Ok(projectResource);
    }
    
    
    [HttpPut]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateProject(int projectId, CreateProjectResource resource)
    {
        var updateProjectCommand = new UpdateProjectCommand(projectId, resource.Name, resource.Description, resource.OngId);
        var project = await projectCommandService.Handle(updateProjectCommand);
        if (project == null) return NotFound();
        var projectResource = ResourceProjectFromEntityAssembler.ToResourceFromEntity(project);
        return Ok(projectResource);
    }
    
    [HttpDelete("{projectId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteProject(int projectId)
    {
        var deleteProjectCommand = new DeleteProjectCommand(projectId);
        var project = await projectCommandService.Handle(deleteProjectCommand);
        if (project == null) return NotFound();
        var projectResource = ResourceProjectFromEntityAssembler.ToResourceFromEntity(project);
        return Ok(projectResource);
    }
    
}