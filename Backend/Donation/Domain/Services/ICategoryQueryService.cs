using Backend.Donation.Domain.Model.Enitities;
using Backend.Donation.Domain.Model.Queries.Category;
using Backend.Donation.Domain.Model.Queries;

namespace Backend.Donation.Domain.Services;

public interface ICategoryQueryService
{
    Task<IEnumerable<Category?>> Handle(GetAllCategoriesQuery query);
    Task<Category?> Handle(GetCategoryByIdQuery query);
}