using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Commnads.DepartmentCommands;
using Backend.Exchange.Domain.Repositories;
using Backend.Exchange.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Application.Internal.CommandServices;

public class DepartmentCommandService(IDepartmentRepository departmentRepository,ICountryRepository countryRepository, IUnitOfWork unitOfWork): IDepartmentCommandService
{
    
    public async Task<Department> Handle(CreateDepartmentCommand command)
    {
        try
        {
            var departmentExist = await departmentRepository.GetByNameAsync(command.Name);
            if(departmentExist != null)
            {
                throw new Exception("Department already exists");
            }
            var country = await countryRepository. FindByIdAsync(command.CountryId);
            if(country == null)
            {
                throw new Exception("Country not found");
            }
            var department = new Department(command);
            await departmentRepository.AddAsync(department);
            await unitOfWork.CompleteAsync();
            return department;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the department: {e.Message}");
            return null;
        }
    }
    
    
    public async Task<Department> Handle(UpdateDepartmentCommand command)
    {
        try
        {
            var department = await departmentRepository.FindByIdAsync(command.Id);
            
            if(department == null)
            {
                throw new Exception("Department not found");
            }
            
            var departmentExist = await departmentRepository.GetByNameAsync(command.Name);
            if(departmentExist != null && departmentExist.Id != command.Id)
            {
                throw new Exception("Department already exists");
            }
            
            var country = await countryRepository. FindByIdAsync(command.CountryId);
            if(country == null)
            {
                throw new Exception("Country not found");
            }
            
            department.Update(command);
            departmentRepository.Update(department);
            await unitOfWork.CompleteAsync();
            return department;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the department: {e.Message}");
            return null;
        }
    }
    
    public async Task<Department> Handle(DeleteDepartmentCommand command)
    {
        try
        {
            var department = await departmentRepository.FindByIdAsync(command.Id);
            
            if(department == null)
            {
                throw new Exception("Department not found");
            }
            departmentRepository.Remove(department);
            await unitOfWork.CompleteAsync();
            return department;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the department: {e.Message}");
            return null;
        }
    }
    
    
    
    
    
}