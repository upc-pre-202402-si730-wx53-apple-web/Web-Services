using DebtGo2.SubscriptionBC.Domain.Model.Commands;
using DebtGo2.SubscriptionBC.Domain.Model.Enums;

namespace DebtGo2.SubscriptionBC.Domain.Model.Aggregates
{
    /// <summary>
    ///     Represents a subscription entity in the domain layer.
    /// </summary>
    /// <remarks>
    ///     This class encapsulates the essential details of a subscription, including the user, plan, 
    ///     start and end dates, and its current status.
    /// </remarks>
    public class Subscription
    {
        /// <summary>
        ///     Gets or sets the unique identifier of the subscription.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the unique identifier of the user associated with the subscription.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the subscription plan.
        /// </summary>
        public string? PlanName { get; set; }

        /// <summary>
        ///     Gets or sets the start date of the subscription.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the end date of the subscription, if applicable.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        ///     Gets or sets the current status of the subscription.
        /// </summary>
        public SubscriptionStatus Status { get; set; }

        public Subscription()
        {
            UserId = string.Empty;
            PlanName = string.Empty;
        }
        public Subscription(CreateSubscriptionCommand command)
        {
            UserId = command.UserId;
            PlanName = command.PlanId;
            StartDate = command.StartDate;
            EndDate = command.EndDate;
            Status = SubscriptionStatus.Active;
        }
    }
}
