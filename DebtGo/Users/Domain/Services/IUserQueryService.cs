using DebtGo.Users.Domain.Model.Aggregates;
using DebtGo.Users.Domain.Model.Queries;

namespace DebtGo.Users.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByEmailQuery query);
    Task<User> Handle(GetUserByIdQuery query);
}