namespace DebtGo2.SubscriptionBC.Domain.Model.Queries
{
    /// <summary>
    ///     Represents a query to retrieve a subscription by its unique identifier.
    /// </summary>
    public class GetSubscriptionByUserIdQuery
    {
        public string UserId { get; }

        public GetSubscriptionByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
