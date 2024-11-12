using DebtGo2.SubscriptionBC.Domain.Model.Aggregates;
using DebtGo2.SubscriptionBC.Interfaces.REST.Resources;

namespace DebtGo2.SubscriptionBC.Interfaces.REST.Transform
{
    /// <summary>
    ///     Assembles a <see cref="SubscriptionResource"/> from a <see cref="Subscription"/> entity.
    /// </summary>
    public class SubscriptionResourceFromEntityAssembler
    {
        /// <summary>
        ///     Converts a <see cref="Subscription"/> entity into a <see cref="SubscriptionResource"/>.
        /// </summary>
        /// <param name="subscription"> The subscription entity.</param>
        /// <returns> A <see cref="SubscriptionResource"/> object.</returns>
        public SubscriptionResource ToResource(Subscription subscription)
        {
            return new SubscriptionResource
            {
                Id = subscription.Id,
                UserId = subscription.UserId,
                PlanName = subscription.PlanName,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
                Status = subscription.Status.ToString()
            };
        }
    }
}
