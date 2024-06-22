using Backend.Exchange.Domain.Model.Enitities;
using Backend.Exchange.Domain.Repositories;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Exchange.Infraestructure.Persistence.EFC.Repositories;

public class CountryRepository(AppDbContext context) : BaseRepository<Country>(context) , ICountryRepository
{
    public async Task<Country?> GetByNameAsync(string name)
    {
        return await Context.Set<Country>()
            .FirstOrDefaultAsync(c => c.Name == name);
    }
}