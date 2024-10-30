using DebtGo.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using DebtGo.Shared.Infrastructure.Persistence.EFC.Configuration;
using DebtGo.Users.Domain.Model.Aggregates;
using DebtGo.Users.Domain.Model.ValueObjects;
using DebtGo.Users.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DebtGo.Users.Infrastructure.Persistence.EFC;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public Task<User?> FindUserByEmailAsync(EmailAddress email)
    {
        return context.Set<User>().Where(p => p.Email == email).FirstOrDefaultAsync();
    }
}