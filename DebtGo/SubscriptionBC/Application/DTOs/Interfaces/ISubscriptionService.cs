using DebtGo.SubscriptionBC.Application.DTOs;

namespace DebtGo.SubscriptionBC.Application.Interfaces
{
    /// <summary>
    ///     Interface for subscription service operations.
    /// </summary>
    /// <remarks>
    ///     This interface defines the contract for managing subscriptions, including basic CRUD operations.
    /// </remarks>
    public interface ISubscriptionService
    {
        /// <summary>
        ///     Retrieves a subscription by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the subscription.</param>
        /// <returns>A <see cref="SubscriptionDto"/> representing the subscription.</returns>
        Task<SubscriptionDto> GetSubscriptionByIdAsync(int id);

        /// <summary>
        ///     Retrieves all subscriptions.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="SubscriptionDto"/> representing all subscriptions.</returns>
        Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync();

        /// <summary>
        ///     Creates a new subscription.
        /// </summary>
        /// <param name="subscription">The <see cref="SubscriptionDto"/> containing the subscription details.</param>
        Task CreateSubscriptionAsync(SubscriptionDto subscription);

        /// <summary>
        ///     Updates an existing subscription.
        /// </summary>
        /// <param name="subscription">The <see cref="SubscriptionDto"/> with updated subscription details.</param>
        Task UpdateSubscriptionAsync(SubscriptionDto subscription);

        /// <summary>
        ///     Deletes a subscription by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the subscription to delete.</param>
        Task DeleteSubscriptionAsync(int id);
    }
}
