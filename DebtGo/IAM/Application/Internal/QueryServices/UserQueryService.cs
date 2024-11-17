using DebtGo.IAM.Domain.Model.Aggregates;
using DebtGo.IAM.Domain.Model.Queries;
using DebtGo.IAM.Domain.Repositories;
using DebtGo.IAM.Domain.Services;

namespace DebtGo.IAM.Application.Internal.QueryServices
{
    public class UserQueryService(IUserRepository userRepository) : IUserQueryService
    {
        /**
         * <summary>
         *     Handle get user by id query
         * </summary>
         * <param name="query">The query object containing the user id to search</param>
         * <returns>The user</returns>
         */
        public async Task<User?> Handle(GetUserByIdQuery query)
        {
            return await userRepository.FindByIdAsync(query.Id);
        }
    }
}