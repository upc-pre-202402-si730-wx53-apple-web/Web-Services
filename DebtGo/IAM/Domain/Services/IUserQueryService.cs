using DebtGo.IAM.Domain.Model.Aggregates;
using DebtGo.IAM.Domain.Model.Queries;

namespace DebtGo.IAM.Domain.Services
{
    public interface IUserQueryService
    {
        /**
         * <summary>
         *     Handle get user by id query
         * </summary>
         * <param name="query">The get user by id query</param>
         * <returns>The user if found, null otherwise</returns>
         */
        Task<User?> Handle(GetUserByIdQuery query);
    }
}