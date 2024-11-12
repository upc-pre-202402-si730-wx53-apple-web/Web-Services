namespace DebtGo2.SubscriptionBC.Interfaces.REST.Resources
{
    /// <summary>
    ///     Represents the resource for creating a subscription.
    /// </summary>
    public class CreateSubscriptionResource
    {
        /// <summary>
        ///     Gets or sets the unique identifier of the user.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the subscription plan.
        /// </summary>
        public string PlanName { get; set; }

        /// <summary>
        ///     Gets or sets the start date of the subscription.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the end date of the subscription, if applicable.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        ///     Gets or sets the status of the subscription.
        /// </summary>
        public string Status { get; set; }
    }
}
