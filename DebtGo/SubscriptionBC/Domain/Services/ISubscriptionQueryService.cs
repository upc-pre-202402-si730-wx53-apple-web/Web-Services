using DebtGo.SubscriptionBC.Interface.Resources;
using DebtGo2.SubscriptionBC.Domain.Model.Aggregates;
using DebtGo2.SubscriptionBC.Domain.Model.Queries;

namespace DebtGo.SubscriptionBC.Domain.Services
{
    /// <summary>
    ///     Interface for subscription-related queries.
    /// </summary>
    public interface ISubscriptionQueryService
    {
        /// <summary>
        ///     Retrieves a subscription by its unique identifier.
        /// </summary>
        /// <param name="id"> The unique identifier of the subscription.</param>
        /// <returns>A <see cref="SubscriptionDto"/> containing the subscription details.</returns>
        Task<SubscriptionDto?> GetSubscriptionByIdAsync(int id);

        /// <summary>
        ///     Retrieves all subscriptions.
        /// </summary>
        /// <returns> An enumerable list of <see cref="SubscriptionDto"/> objects.</returns>
        Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync();
        Task<Subscription> Handle(GetSubscriptionByUserIdQuery getSubscriptionByUserIdQuery);
    }
}
