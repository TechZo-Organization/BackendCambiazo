using Backend.Exchange.Domain.Model.Commnads.DepartmentCommands;
using Backend.Exchange.Domain.Services;
using Backend.Exchange.Interfaces.REST.Resources;
using Backend.Exchange.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Exchange.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class DepartmentController(IDepartmentCommandService departmentCommandService): ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> CreateDepartment(CreateDepartmentResource resource)
    {
        var createDepartmentCommand = CreateDepartmentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var department = await departmentCommandService.Handle(createDepartmentCommand);
        if (department is null) return BadRequest();
        var departmentResource = DepartmentResourceFromEntityAssembler.ToResourceFromEntity(department);
        //return CreatedAtAction(nameof(GetDepartmentById), new {departmentId = departmentResource.Id}, departmentResource);
        return Ok(departmentResource);
    }
    
    [HttpPut("{departmentId:int}")]
    public async Task<IActionResult> UpdateDepartment(int departmentId, CreateDepartmentResource resource)
    {
        var updateDepartmentCommand = new UpdateDepartmentCommand(departmentId, resource.Name, resource.CountryId);
        var department = await departmentCommandService.Handle(updateDepartmentCommand);
        if (department == null) return NotFound();
        var departmentResource = DepartmentResourceFromEntityAssembler.ToResourceFromEntity(department);
        return Ok(departmentResource);
    }
    
    [HttpDelete("{departmentId:int}")]
    public async Task<IActionResult> DeleteDepartment(int departmentId)
    {
        var deleteDepartmentCommand = new DeleteDepartmentCommand(departmentId);
        var department = await departmentCommandService.Handle(deleteDepartmentCommand);
        if (department == null) return NotFound();
        var departmentResource = DepartmentResourceFromEntityAssembler.ToResourceFromEntity(department);
        return Ok(departmentResource);
    }
}
