using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Model.Commnads.Project;
using Backend.Donation.Domain.Model.Commnads.Category;

namespace Backend.Donation.Domain.Services;

public interface IProjectCommandService
{
    //update, delete and post
    Task<Project> Handle(CreateProjectCommand command);
    Task<Project> Handle(UpdateProjectCommand command);
    Task<Project> Handle(DeleteProjectCommand command);
}