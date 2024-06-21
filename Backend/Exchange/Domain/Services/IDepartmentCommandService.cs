using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Commnads.DepartmentCommands;

namespace Backend.Exchange.Domain.Services;

public interface IDepartmentCommandService
{
    Task<Department> Handle(CreateDepartmentCommand command);
    Task<Department> Handle(UpdateDepartmentCommand command);
    Task<Department> Handle(DeleteDepartmentCommand command);
}