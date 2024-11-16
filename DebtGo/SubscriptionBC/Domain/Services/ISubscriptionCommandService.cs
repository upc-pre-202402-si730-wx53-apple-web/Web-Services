using DebtGo.SubscriptionBC.Interface.Resources;
using DebtGo2.SubscriptionBC.Domain.Model.Aggregates;
using DebtGo2.SubscriptionBC.Domain.Model.Commands;

namespace DebtGo.SubscriptionBC.Domain.Services
{
    /// <summary>
    ///     Interface for subscription-related commands.
    /// </summary>
    public interface ISubscriptionCommandService
    {
        /// <summary>
        ///     Creates a new subscription.
        /// </summary>
        /// <param name="subscription"> The subscription data transfer object.</param>
        Task CreateSubscriptionAsync(SubscriptionDto subscription);

        /// <summary>
        ///     Updates an existing subscription.
        /// </summary>
        /// <param name="subscription"> The subscription data transfer object with updated details.</param>
        Task UpdateSubscriptionAsync(SubscriptionDto subscription);

        /// <summary>
        ///     Deletes a subscription by its unique identifier.
        /// </summary>
        /// <param name="id"> The unique identifier of the subscription to delete.</param>
        Task DeleteSubscriptionAsync(int id);
        Task<Subscription> Handle(CreateSubscriptionCommand createSubscriptionCommand);
    }
}
