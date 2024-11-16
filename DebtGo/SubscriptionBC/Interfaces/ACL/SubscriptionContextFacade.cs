using DebtGo.SubscriptionBC.Domain.Services;
using DebtGo2.SubscriptionBC.Domain.Model.Commands;
using DebtGo2.SubscriptionBC.Domain.Model.Queries;

namespace DebtGo2.SubscriptionBC.Interfaces.ACL
{
    public class SubscriptionContextFacade : ISubscriptionContextFacade
    {
        private readonly ISubscriptionCommandService _subscriptionCommandService;
        private readonly ISubscriptionQueryService _subscriptionQueryService;

        public SubscriptionContextFacade(
            ISubscriptionCommandService subscriptionCommandService,
            ISubscriptionQueryService subscriptionQueryService)
        {
            _subscriptionCommandService = subscriptionCommandService;
            _subscriptionQueryService = subscriptionQueryService;
        }

        public async Task<int> CreateSubscription(string userId, string planName, DateTime startDate, DateTime? endDate, string status)
        {
            var createSubscriptionCommand = new CreateSubscriptionCommand(userId, planName, startDate, endDate ?? DateTime.MaxValue, status);
            var subscription = await _subscriptionCommandService.Handle(createSubscriptionCommand);
            return subscription.Id; // Id ahora es accesible
        }

        public async Task<int> FetchSubscriptionIdByUserId(string userId)
        {
            var getSubscriptionByUserIdQuery = new GetSubscriptionByUserIdQuery(userId);
            var subscription = await _subscriptionQueryService.Handle(getSubscriptionByUserIdQuery);
            return subscription.Id; // Id ahora es accesible
        }
    }
}
