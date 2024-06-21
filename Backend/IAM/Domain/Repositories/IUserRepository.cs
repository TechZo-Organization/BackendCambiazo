using Backend.IAM.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByEmailAsync(string email);
    bool ExistsByEmail(string email);
}