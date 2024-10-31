namespace DebtGo.SubscriptionBC.Domain.Enums
{
    /// <summary>
    ///     Represents the different statuses a subscription can have.
    /// </summary>
    /// <remarks>
    ///     The subscription status indicates the current state of a subscription, which could be 
    ///     active, inactive, or cancelled.
    /// </remarks>
    public enum SubscriptionStatus
    {
        /// <summary>
        ///     The subscription is currently active and operational.
        /// </summary>
        Active,

        /// <summary>
        ///     The subscription is inactive but not yet cancelled.
        /// </summary>
        Inactive,

        /// <summary>
        ///     The subscription has been cancelled and is no longer valid.
        /// </summary>
        Cancelled
    }
}
