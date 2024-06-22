using Backend.Profiles.Domain.Model.Aggregates;
using Backend.Profiles.Domain.Model.Commands.BenefitCommands;

namespace Backend.Profiles.Domain.Services;

public interface IBenefitCommandService
{
    Task<Benefit> Handle(CreateBenefitCommand command);
    Task<Benefit> Handle(UpdateBenefitCommand command);
    Task<Benefit> Handle(DeleteBenefitCommand command);
}