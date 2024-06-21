namespace Backend.Exchange.Domain.Model.Queries.ProductQueries;

public record GetAllAvailableProductsByBetweenPricesAndDistrictAndWordNameAndCategoryQuery(
    int MinPrice,
    int MaxPrice,
    int DistrictId,
    string WordName,
    int CategoryId
    );