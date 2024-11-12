using DebtGo2.SubscriptionBC.Domain.Model.Aggregates;

namespace DebtGo2.SubscriptionBC.Domain.Repositories
{
    /// <summary>
    ///     Interface for the subscription repository.
    /// </summary>
    public interface ISubscriptionRepository
    {
        /// <summary>
        ///     Adds a new subscription.
        /// </summary>
        /// <param name="subscription"> The subscription to add.</param>
        Task AddAsync(Subscription subscription);

        /// <summary>
        ///     Retrieves a subscription by its unique identifier.
        /// </summary>
        /// <param name="id"> The subscription's unique identifier.</param>
        /// <returns> The subscription, or null if it does not exist.</returns>
        Task<Subscription?> GetByIdAsync(int id);

        /// <summary>
        ///     Retrieves all subscriptions.
        /// </summary>
        /// <returns> A collection of subscriptions.</returns>
        Task<IEnumerable<Subscription>> GetAllAsync();

        /// <summary>
        ///     Updates an existing subscription.
        /// </summary>
        /// <param name="subscription"> The subscription to update.</param>
        Task UpdateAsync(Subscription subscription);

        /// <summary>
        ///     Deletes a subscription by its unique identifier.
        /// </summary>
        /// <param name="id"> The subscription's unique identifier.</param>
        Task DeleteAsync(int id);
    }
}
