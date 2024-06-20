using Backend.Donation.Domain.Model.Enitities;
using Backend.Shared.Domain.Repositories;

namespace Backend.Donation.Domain.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category?> FindByName(string name);
}