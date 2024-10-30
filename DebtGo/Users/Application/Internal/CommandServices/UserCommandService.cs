using DebtGo.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using DebtGo.Shared.Domain.Repositories;
using DebtGo.Users.Domain.Model.Aggregates;
using DebtGo.Users.Domain.Model.Commands;
using DebtGo.Users.Domain.Repositories;
using DebtGo.Users.Domain.Services;

namespace DebtGo.Users.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork) : IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        var profile = new User(command);
        try
        {
            await userRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error ocurred while creating the profile: {e.Message}");
            return null;
            
        }
    }
}