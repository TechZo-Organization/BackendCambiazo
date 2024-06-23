using Backend.Profiles.Domain.Model.Commands.MembershipCommands;
using Backend.Profiles.Domain.Model.Entities;

namespace Backend.Profiles.Domain.Services;

public interface IMembershipCommandService
{
    
    Task<Membership> Handle(CreateMembershipCommand command);
    Task<Membership> Handle(UpdateMembershipCommand command);
    Task<Membership> Handle(DeleteMembershipCommand command);
}