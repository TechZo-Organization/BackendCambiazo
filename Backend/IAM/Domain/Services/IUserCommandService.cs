using Backend.IAM.Domain.Model.Aggregates;
using Backend.IAM.Domain.Model.Commands;

namespace Backend.IAM.Domain.Services;

public interface IUserCommandService
{
    Task<(User user, string token)> Handle(SignInCommand command);

    Task Handle(SignUpCommand command);
}