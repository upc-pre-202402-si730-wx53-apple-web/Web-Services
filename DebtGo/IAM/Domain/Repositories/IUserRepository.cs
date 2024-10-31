using DebtGo.IAM.Domain.Model.Aggregates;
using DebtGo.Shared.Domain.Repositories;

namespace DebtGo.IAM.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> FindByEmailAsync(string email);
    }
}