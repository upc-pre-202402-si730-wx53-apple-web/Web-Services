namespace DebtGo2.SubscriptionBC.Domain.Model.Queries
{
    /// <summary>
    ///     Represents a query to retrieve a subscription by its unique identifier.
    /// </summary>
    public class GetSubscriptionByIdQuery
    {
        /// <summary>
        ///     Unique identifier of the subscription.
        /// </summary>
        public int SubscriptionId { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetSubscriptionByIdQuery"/> class.
        /// </summary>
        /// <param name="subscriptionId"> The unique identifier of the subscription.</param>
        public GetSubscriptionByIdQuery(int subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }
    }
}
