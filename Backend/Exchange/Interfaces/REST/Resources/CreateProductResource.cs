namespace Backend.Exchange.Interfaces.REST.Resources;

public record CreateProductResource(
        string Name,
        string Description,
        string ObjectChange,
        float Price,
        string Photo,
        bool Boost,
        bool Available,
        int CategoryId,
        int UserId,
        int DistrictId
    );