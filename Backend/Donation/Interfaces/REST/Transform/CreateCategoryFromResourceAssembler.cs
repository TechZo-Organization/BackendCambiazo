using Backend.Donation.Domain.Model.Commnads.Category;
using Backend.Donation.Interfaces.REST.Resources;
using Backend.Donation.Domain.Model.Commnads;

namespace Backend.Donation.Interfaces.REST.Transform;

public class CreateCategoryFromResourceAssembler
{
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(resource.Name);
    }
}