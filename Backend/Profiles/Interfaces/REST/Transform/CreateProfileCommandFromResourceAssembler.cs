using Backend.Profiles.Domain.Model.Commands;
using Backend.Profiles.Interfaces.REST.Resources;

namespace Backend.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.FirstName, resource.LastName, resource.Email, resource.Phone,
            resource.Photo);
    }
}