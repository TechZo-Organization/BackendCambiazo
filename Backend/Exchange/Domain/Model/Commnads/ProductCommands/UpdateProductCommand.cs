namespace Backend.Exchange.Domain.Model.Commnads.ProductCommands;

public record UpdateProductCommand(
        int Id,
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