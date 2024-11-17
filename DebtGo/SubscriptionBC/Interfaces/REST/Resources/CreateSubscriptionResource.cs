namespace DebtGo2.SubscriptionBC.Interfaces.REST.Resources
{
    /// <summary>
    ///     Represents the resource for creating a subscription.
    /// </summary>
    public record CreateSubscriptionResource(
        /// <summary>
        ///     Gets or sets the unique identifier of the user.
        /// </summary>
        string UserId,

        /// <summary>
        ///     Gets or sets the name of the subscription plan.
        /// </summary>
        string PlanName,

        /// <summary>
        ///     Gets or sets the start date of the subscription.
        /// </summary>
        DateTime StartDate,

        /// <summary>
        ///     Gets or sets the end date of the subscription, if applicable.
        /// </summary>
        DateTime? EndDate,

        /// <summary>
        ///     Gets or sets the status of the subscription.
        /// </summary>
        string Status
    );
}
