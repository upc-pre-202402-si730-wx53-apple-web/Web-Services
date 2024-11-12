using System;

namespace DebtGo2.SubscriptionBC.Domain.Model.Events
{
    /// <summary>
    ///     Event triggered when a subscription is activated.
    /// </summary>
    public class SubscriptionActivatedEvent
    {
        /// <summary>
        ///     Unique identifier of the activated subscription.
        /// </summary>
        public int SubscriptionId { get; }

        /// <summary>
        ///     Unique identifier of the user associated with the subscription.
        /// </summary>
        public string UserId { get; }

        /// <summary>
        ///     Date and time when the subscription was activated.
        /// </summary>
        public DateTime ActivatedOn { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SubscriptionActivatedEvent"/> class.
        /// </summary>
        /// <param name="subscriptionId"> Unique identifier of the subscription.</param>
        /// <param name="userId"> Unique identifier of the user.</param>
        /// <param name="activatedOn"> Activation date and time.</param>
        public SubscriptionActivatedEvent(int subscriptionId, string userId, DateTime activatedOn)
        {
            SubscriptionId = subscriptionId;
            UserId = userId;
            ActivatedOn = activatedOn;
        }
    }
}
