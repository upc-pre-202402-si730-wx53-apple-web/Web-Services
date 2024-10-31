using DebtGo.IAM.Domain.Model.Aggregates;
using DebtGo.IAM.Domain.Repositories;
using DebtGo.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using DebtGo.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DebtGo.IAM.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public async Task<User?> FindByEmailAsync(string email)
        {
            return await context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}