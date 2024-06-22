using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Interfaces.REST.Resources;

namespace Backend.Profiles.Interfaces.REST.Transform;

public class ReviewResourceFromEntityAssembler
{
    public static ReviewResource ToResourceFromEntity(Review review)
    {
        return new ReviewResource(
            review.Id,
            review.Message,
            review.State,
            review.ProfileAuthorId,
            review.ProfileReceptorId,
            review.OfferId
        );
    }
}