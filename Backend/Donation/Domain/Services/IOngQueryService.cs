using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Model.Queries.Category;
using Backend.Donation.Domain.Model.Queries.Ong;
using Backend.Donation.Domain.Model.Queries;

namespace Backend.Donation.Domain.Services;

public interface IOngQueryService
{
    Task<IEnumerable<Ong>> Handle(GetAllOngsQuery query);
    Task<IEnumerable<Ong>> Handle(GetAllOngByWordAddress query);
    Task<IEnumerable<Ong>> Handle(GetAllOngByWordName query);
    Task<IEnumerable<Ong>> Handle(GetAllOngByCategory query);
    Task<Ong?> Handle(GetOngByIdQuery query);
    
    
}