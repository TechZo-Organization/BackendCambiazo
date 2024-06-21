using Backend.Donation.Domain.Model.Enitities;
using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Enitities;

namespace Backend.Exchange.Interfaces.REST.Resources;

public record ProductResource
(
    int Id,
    string Name,
    string Description,
    string ObjectChange,
    float Price,
    string Photo,
    bool Boost,
    bool Available,
    ProductCategory Category,
    int UserId,
    District District
);