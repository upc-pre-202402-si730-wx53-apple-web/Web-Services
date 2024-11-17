namespace DebtGo2.SubscriptionBC.Interfaces.ACL
{
    public interface ISubscriptionContextFacade
    {
        Task<int> CreateSubscription(string userId, string planName, DateTime startDate, DateTime? endDate, string status);
        Task<int> FetchSubscriptionIdByUserId(string userId);
    }
}
