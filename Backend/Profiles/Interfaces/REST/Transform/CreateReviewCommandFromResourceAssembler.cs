using Backend.Profiles.Domain.Model.Commands.ReviewCommands;
using Backend.Profiles.Interfaces.REST.Resources;

namespace Backend.Profiles.Interfaces.REST.Transform;

public class CreateReviewCommandFromResourceAssembler
{
    public static CreateReviewCommand ToCommandFromResource(CreateReviewResource resource)
    {
        return new CreateReviewCommand(
            resource.Message,
            resource.State,
            resource.ProfileAuthorId,
            resource.ProfileReceptorId,
            resource.OfferId
        );
    }
}