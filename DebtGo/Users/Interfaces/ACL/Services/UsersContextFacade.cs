using DebtGo.Users.Domain.Model.Commands;
using DebtGo.Users.Domain.Model.Queries;
using DebtGo.Users.Domain.Model.ValueObjects;
using DebtGo.Users.Domain.Services;

namespace DebtGo.Users.Interfaces.ACL.Services;

public class UsersContextFacade(IUserCommandService userCommandService, IUserQueryService userQueryService) : IUsersContextFacade
{
    public async Task<int> CreateUser(string firstName, string lastName, string email)
    {
        var createUserCommand = new CreateUserCommand(firstName, lastName, email);
        var user = await userCommandService.Handle(createUserCommand);
        return user?.Id ?? 0;
    }
    
    public async Task<int> FetchUserIdByEmail(string email)
    {
        var getUserByEmailQuery = new GetUserByEmailQuery(new EmailAddress(email));
        var user = await userQueryService.Handle(getUserByEmailQuery);
        return user?.Id ?? 0;
    }
}