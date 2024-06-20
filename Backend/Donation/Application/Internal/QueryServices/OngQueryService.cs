using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Model.Queries.Category;
using Backend.Donation.Domain.Model.Queries.Ong;
using Backend.Donation.Domain.Repositories;
using Backend.Donation.Domain.Services;
using Backend.Shared.Domain.Repositories;
using Backend.Donation.Domain.Model.Queries;

namespace Backend.Donation.Application.Internal.QueryServices;

public class OngQueryService(IOngRepository ongRepository,ICategoryRepository categoryRepository,IUnitOfWork unitOfWork) : IOngQueryService
{
    public async Task<IEnumerable<Ong>> Handle(GetAllOngsQuery query)
    {
        return await ongRepository.ListAsync();
    }

    public async Task<IEnumerable<Ong>> Handle(GetAllOngByWordAddress query)
    {
        return await ongRepository.GetAllByWordAddress(query.WordAddress);
    }

    public async Task<IEnumerable<Ong>> Handle(GetAllOngByWordName query)
    {
        return await ongRepository.GetAllByWordName(query.WordName);
    }

    public async Task<IEnumerable<Ong>> Handle(GetAllOngByCategory query)
    {

        try
        {
            var existCategory = await categoryRepository.FindByIdAsync(query.CategoryId);
            if (query.CategoryId == null)
            {
                throw new Exception("Category not found");
            }
            return await ongRepository.GetAllByCategory(query.CategoryId);
            
        }
        catch(Exception e)
        {
            Console.WriteLine($"An error occurred while getting the ong by category: {e.Message}");
            return null;
        }
        
    }

    public async Task<Ong?> Handle(GetOngByIdQuery query)
    {
        return await ongRepository.FindByIdAsync(query.Id);
    }
}