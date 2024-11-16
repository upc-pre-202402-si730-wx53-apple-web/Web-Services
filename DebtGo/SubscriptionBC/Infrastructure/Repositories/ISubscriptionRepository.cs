using DebtGo2.SubscriptionBC.Domain.Model.Aggregates;

namespace DebtGo2.SubscriptionBC.Infrastructure.Persistence.EFC.Repositories
{
    /// <summary>
    ///     Interface for the Subscription repository.
    /// </summary>
    /// <remarks>
    ///     This interface defines the contract for operations related to the <see cref="Subscription"/> 
    ///     entity, including retrieval, creation, updating, and deletion of subscriptions.
    /// </remarks>
    public interface ISubscriptionRepository
    {
        /// <summary>
        ///     Gets a subscription by its unique identifier.
        /// </summary>
        /// <param name="id"> The unique identifier of the subscription.</param>
        /// <returns>A <see cref="Task{Subscription}"/> representing the asynchronous operation, containing the found subscription.</returns>
        Task<Subscription> GetByIdAsync(int id);

        /// <summary>
        ///     Gets all subscriptions.
        /// </summary>
        /// <returns>A <see cref="Task{IEnumerable{Subscription}}"/> representing the asynchronous operation, containing a list of subscriptions.</returns>
        Task<IEnumerable<Subscription>> GetAllAsync();

        /// <summary>
        ///     Adds a new subscription.
        /// </summary>
        /// <param name="subscription"> The subscription to add.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddAsync(Subscription subscription);

        /// <summary>
        ///     Updates an existing subscription.
        /// </summary>
        /// <param name="subscription"> The subscription with updated information.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task UpdateAsync(Subscription subscription);

        /// <summary>
        ///     Deletes a subscription by its unique identifier.
        /// </summary>
        /// <param name="id"> The unique identifier of the subscription to delete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task DeleteAsync(int id);
    }
}
