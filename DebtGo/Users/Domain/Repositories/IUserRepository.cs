using DebtGo.Shared.Domain.Repositories;
using DebtGo.Users.Domain.Model.Aggregates;
using DebtGo.Users.Domain.Model.ValueObjects;

namespace DebtGo.Users.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindUserByEmailAsync(EmailAddress email);
}