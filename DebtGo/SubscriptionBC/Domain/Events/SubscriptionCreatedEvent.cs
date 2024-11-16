namespace DebtGo2.SubscriptionBC.Domain.Model.Events
{
    /// <summary>
    ///     Represents an event that occurs when a new subscription is created.
    /// </summary>
    /// <remarks>
    ///     This event encapsulates the essential details of a newly created subscription, 
    ///     including the subscription ID, user ID, plan name, and start date.
    /// </remarks>
    public class SubscriptionCreatedEvent
    {
        /// <summary>
        ///     Gets the unique identifier of the created subscription.
        /// </summary>
        public int SubscriptionId { get; }

        /// <summary>
        ///     Gets the unique identifier of the user associated with the subscription.
        /// </summary>
        public string UserId { get; }

        /// <summary>
        ///     Gets the name of the plan associated with the subscription.
        /// </summary>
        public string PlanName { get; }

        /// <summary>
        ///     Gets the start date of the subscription.
        /// </summary>
        public DateTime StartDate { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SubscriptionCreatedEvent"/> class.
        /// </summary>
        /// <param name="subscriptionId"> The unique identifier of the subscription.</param>
        /// <param name="userId"> The unique identifier of the user.</param>
        /// <param name="planName"> The name of the subscription plan.</param>
        /// <param name="startDate"> The start date of the subscription.</param>
        public SubscriptionCreatedEvent(int subscriptionId, string userId, string planName, DateTime startDate)
        {
            SubscriptionId = subscriptionId;
            UserId = userId;
            PlanName = planName;
            StartDate = startDate;
        }
    }
}
