using Backend.Exchange.Domain.Model.Aggregates;
using Backend.Exchange.Domain.Model.Commnads.DistrictCommands;

namespace Backend.Exchange.Domain.Services;

public interface IDistrictCommandService
{
    Task<District> Handle(CreateDistrictCommand command);
    Task<District> Handle(UpdateDistrictCommand command);
    Task<District> Handle(DeleteDistrictCommand command);
}