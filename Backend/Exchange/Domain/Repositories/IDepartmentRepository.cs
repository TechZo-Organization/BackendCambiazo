using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend.Exchange.Domain.Repositories;

public interface IDepartmentRepository : IBaseRepository<Department>
{
    Task<Department?> GetByNameAsync(string name);
}