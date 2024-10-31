using Microsoft.EntityFrameworkCore;
using DebtGo.SubscriptionBC.Domain.Entities;
using DebtGo.SubscriptionBC.Infrastructure.Data;

namespace DebtGo.SubscriptionBC.Infrastructure.Repositories
{
    /// <summary>
    ///     Implementation of the <see cref="ISubscriptionRepository"/> interface.
    /// </summary>
    /// <remarks>
    ///     This class provides the data access methods for managing <see cref="Subscription"/> entities 
    ///     in the database using Entity Framework Core.
    /// </remarks>
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly SubscriptionDbContext _context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SubscriptionRepository"/> class.
        /// </summary>
        /// <param name="context">The database context for accessing subscriptions.</param>
        public SubscriptionRepository(SubscriptionDbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Gets a subscription by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the subscription.</param>
        /// <returns>A <see cref="Task{Subscription}"/> representing the asynchronous operation, containing the found subscription.</returns>
        public async Task<Subscription> GetByIdAsync(int id)
        {
            return await _context.Subscriptions.FindAsync(id);
        }

        /// <summary>
        ///     Gets all subscriptions.
        /// </summary>
        /// <returns>A <see cref="Task{IEnumerable{Subscription}}"/> representing the asynchronous operation, containing a list of subscriptions.</returns>
        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        /// <summary>
        ///     Adds a new subscription.
        /// </summary>
        /// <param name="subscription">The subscription to add.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task AddAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        ///     Updates an existing subscription.
        /// </summary>
        /// <param name="subscription">The subscription with updated information.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task UpdateAsync(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        ///     Deletes a subscription by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the subscription to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task DeleteAsync(int id)
        {
            var subscription = await GetByIdAsync(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
            }
        }
    }
}
