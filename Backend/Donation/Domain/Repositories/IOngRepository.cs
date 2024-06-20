using Backend.Donation.Domain.Model.Aggregates;
using Backend.Shared.Domain.Repositories;

namespace Backend.Donation.Domain.Repositories;

public interface IOngRepository : IBaseRepository<Ong>
{
    Task<IEnumerable<Ong>> GetAllByWordName(string wordName);
    Task<IEnumerable<Ong>> GetAllByWordAddress(string wordAddress);
    Task<IEnumerable<Ong>> GetAllByCategory(int categoryId);
   
}