using Backend.IAM.Application.Internal.OutboundServices;
using Backend.IAM.Domain.Model.Aggregates;
using Backend.IAM.Domain.Model.Commands;
using Backend.IAM.Domain.Repositories;
using Backend.IAM.Domain.Services;
using Backend.Shared.Domain.Repositories;

namespace Backend.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork):IUserCommandService
{
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByEmailAsync(command.Email);

        if (user == null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid email or password");

        var token = tokenService.GenerateToken(user);

        return (user, token);
    }
    
    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByEmail(command.Email))
            throw new Exception($"Email {command.Email} is already taken");

        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.Email, hashedPassword);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating user: {e.Message}");
        }
    }
    
    public async Task<User> Handle(UpdateUserCommand command)
    {
        var user = await userRepository.FindByIdAsync(command.id);
        if (user == null)
            throw new Exception($"User with id {command.id} not found");

        user.UpdateUserEmail(command.email);
        user.UpdatePasswordHash(hashingService.HashPassword(command.passwordHash));
        
        try
        {
            userRepository.Update(user);
            await unitOfWork.CompleteAsync();
            return user;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while updating user: {e.Message}");
        }
    }
    
    public async Task<User> Handle(DeleteUserCommand command)
    {
        var user = await userRepository.FindByIdAsync(command.id);
        if (user == null)
            throw new Exception($"User with id {command.id} not found");
        try
        {
            userRepository.Remove(user);
            await unitOfWork.CompleteAsync();
            return user;

        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while deleting user: {e.Message}");
        }
    }
}