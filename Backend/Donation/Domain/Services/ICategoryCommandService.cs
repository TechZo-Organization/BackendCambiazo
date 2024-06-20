using Backend.Donation.Domain.Model.Commnads.Category;
using Backend.Donation.Domain.Model.Enitities;
using Backend.Donation.Domain.Model.Commnads;

namespace Backend.Donation.Domain.Services;

public interface ICategoryCommandService
{
    Task<Category> Handle(CreateCategoryCommand command);
    Task<Category> Handle(UpdateCategoryCommand command);
    Task<Category> Handle(DeleteCategoryCommand command);
}