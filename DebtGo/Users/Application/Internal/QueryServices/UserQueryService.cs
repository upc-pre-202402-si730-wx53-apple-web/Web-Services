using DebtGo.Users.Domain.Model.Aggregates;
using DebtGo.Users.Domain.Model.Queries;
using DebtGo.Users.Domain.Repositories;
using DebtGo.Users.Domain.Services;

namespace DebtGo.Users.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    public async Task<User?> Handle(GetUserByEmailQuery query)
    {
        return await userRepository.FindUserByEmailAsync(query.Email);
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }
}