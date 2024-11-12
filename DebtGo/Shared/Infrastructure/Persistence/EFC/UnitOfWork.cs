using Microsoft.EntityFrameworkCore;
using DebtGo2.Shared.Domain.Repositories;
using DebtGo.SubscriptionBC.Infrastructure.Data;

namespace DebtGo2.Shared.Infrastructure.Persistence.EFC
{
    /// <summary>
    ///     Implementation of the unit of work to handle transactions.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The subscription-specific database context.
        /// </summary>
        private readonly SubscriptionDbContext _context;

        /// <summary>
        ///     Initialize a new instance of <see cref="UnitOfWork"/>.
        /// </summary>
        /// <param name="context"> The database context.</param>
        public UnitOfWork(SubscriptionDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
