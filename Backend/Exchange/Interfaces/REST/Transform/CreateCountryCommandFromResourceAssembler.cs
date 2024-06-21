using Backend.Exchange.Domain.Model.Commnads.CountryCommands;
using Backend.Exchange.Interfaces.REST.Resources;

namespace Backend.Exchange.Interfaces.REST.Transform;

public class CreateCountryCommandFromResourceAssembler
{
    public static CreateCountryCommand ToCommandFromResource(CreateCountryResource resource)
    {
        return new CreateCountryCommand(resource.Name);
    }
}