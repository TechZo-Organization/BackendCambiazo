using Backend.Exchange.Domain.Model.Commnads.CountryCommands;
using Backend.Exchange.Domain.Model.Enitities;

namespace Backend.Exchange.Domain.Services;

public interface ICountryCommandService
{
     Task<Country> Handle(CreateCountryCommand command);
     Task<Country> Handle(UpdateCountryCommand command);
     Task<Country> Handle(DeleteCountryCommand command);
}