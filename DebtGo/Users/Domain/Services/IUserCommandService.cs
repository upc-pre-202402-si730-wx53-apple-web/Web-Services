using DebtGo.Users.Domain.Model.Aggregates;
using DebtGo.Users.Domain.Model.Commands;

namespace DebtGo.Users.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
}