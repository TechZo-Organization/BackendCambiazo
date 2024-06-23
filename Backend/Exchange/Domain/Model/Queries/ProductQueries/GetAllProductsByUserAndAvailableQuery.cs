namespace Backend.Exchange.Domain.Model.Queries.ProductQueries;

public record GetAllProductsByUserAndAvailableQuery(int UserId, bool Available);
