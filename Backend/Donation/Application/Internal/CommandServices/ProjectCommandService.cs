using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Model.Commnads.Project;
using Backend.Donation.Domain.Repositories;
using Backend.Donation.Domain.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Donation.Domain.Model.Commnads.Category;

namespace Backend.Donation.Application.Internal.CommandServices;

public class ProjectCommandService(IProjectRepository projectRepository,IOngRepository ongRepository,IUnitOfWork unitOfWork) : IProjectCommandService
{
    
    public async Task<Project> Handle(CreateProjectCommand command)
    {
        try
        {
            var ong = await ongRepository.FindByIdAsync(command.OngId);
            if(ong == null)
            {
                throw new Exception("Ong not found");
            }
            var project = new Project(command);
            await projectRepository.AddAsync(project);
            await unitOfWork.CompleteAsync();
            return project;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the project: {e.Message}");
            return null;
        }
    }
    
    
    public async Task<Project> Handle(UpdateProjectCommand command)
    {
        try
        {
            var project = await projectRepository.FindByIdAsync(command.Id);
            
            if(project == null)
            {
                throw new Exception("Project not found");
            }
            
           
            var ong = await ongRepository.FindByIdAsync(command.OngId);
            if(ong == null)
            {
                throw new Exception("Ong not found");
            }
            
            project.Update(command);
            projectRepository.Update(project);
            await unitOfWork.CompleteAsync();
            return project;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the project: {e.Message}");
            return null;
        }
    }
    
    public async Task<Project> Handle(DeleteProjectCommand command)
    {
        try
        {
            var project = await projectRepository.FindByIdAsync(command.Id);
            
            if(project == null)
            {
                throw new Exception("Project not found");
            }
            
            
            projectRepository.Remove(project);
            await unitOfWork.CompleteAsync();
            return project;
            
        }catch (Exception e)
        {
            Console.WriteLine($"An error occurred while deleting the project: {e.Message}");
            return null;
        }
    }

    
}