using Microsoft.EntityFrameworkCore;
using DebtGo2.SubscriptionBC.Domain.Model.Aggregates;
using DebtGo.Shared.Infrastructure.Persistence.EFC.Configuration;
using DebtGo.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using DebtGo2.SubscriptionBC.Domain.Repositories;

namespace DebtGo2.SubscriptionBC.Infrastructure.Persistence.EFC.Repositories
{
    /// <summary>
    ///     Implementation of the <see cref="ISubscriptionRepository"/> interface.
    /// </summary>
    /// <remarks>
    ///     This class provides the data access methods for managing <see cref="Subscription"/> entities 
    ///     in the database using Entity Framework Core.
    /// </remarks>
    public class SubscriptionRepository(AppDbContext context) : BaseRepository<Subscription>(context), ISubscriptionRepository
    {

    }
}
