using Backend.Donation.Domain.Model.Enitities;
using Backend.Donation.Domain.Model.Queries.Category;
using Backend.Donation.Domain.Repositories;
using Backend.Donation.Domain.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Donation.Domain.Model.Queries;

namespace Backend.Donation.Application.Internal.QueryServices;

public class CategoryQueryService(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork) : ICategoryQueryService
{
    public async Task<IEnumerable<Category?>> Handle(GetAllCategoriesQuery query)
    {
        return await categoryRepository.ListAsync();
    }

    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        return await categoryRepository.FindByIdAsync(query.Id);
    }
}