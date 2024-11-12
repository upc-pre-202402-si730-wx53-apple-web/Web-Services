namespace DebtGo2.SubscriptionBC.Domain.Model.Commands
{
    /// <summary>
    /// Represents a command to create a new subscription.
    /// </summary>
    public class CreateSubscriptionCommand
    {
        /// <summary>
        ///     Unique identifier of the user associated with the subscription.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///     Name of the subscription plan.
        /// </summary>
        public string PlanName { get; set; }

        /// <summary>
        ///     Start date of the subscription.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     End date of the subscription, if applicable.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        ///     Current status of the subscription.
        /// </summary>
        public string Status { get; set; }
    }
}
