using DebtGo.SubscriptionBC.Interface.Resources;
using DebtGo.SubscriptionBC.Domain.Services;
using DebtGo2.SubscriptionBC.Infrastructure.Persistence.EFC.Repositories;
using DebtGo2.SubscriptionBC.Domain.Model.Aggregates;
using DebtGo2.SubscriptionBC.Domain.Model.Queries;

namespace DebtGo2.SubscriptionBC.Application.Internal.QueryServices
{
    /// <summary>
    ///     Implements the query service for managing subscriptions.
    /// </summary>
    public class SubscriptionQueryService : ISubscriptionQueryService
    {
        private readonly ISubscriptionRepository _repository;

        /// <summary>
        ///     Initializes a new instance of <see cref="SubscriptionQueryService"/>.
        /// </summary>
        /// <param name="repository"> The repository used to query subscription data.</param>
        public SubscriptionQueryService(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        ///     Retrieves a subscription by its unique identifier.
        /// </summary>
        /// <param name="id"> The unique identifier of the subscription.</param>
        /// <returns>A <see cref="SubscriptionDto"/> object containing the subscription details.</returns>
        public async Task<SubscriptionDto?> GetSubscriptionByIdAsync(int id)
        {
            var subscription = await _repository.GetByIdAsync(id);
            return new SubscriptionDto
            {
                Id = subscription.Id,
                UserId = subscription.UserId,
                PlanName = subscription.PlanName,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
                Status = subscription.Status.ToString()
            };
        }

        /// <summary>
        ///     Retrieves all subscriptions.
        /// </summary>
        /// <returns> An enumerable list of <see cref="SubscriptionDto"/> objects.</returns>
        public async Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync()
        {
            var subscriptions = await _repository.GetAllAsync();
            return subscriptions.Select(s => new SubscriptionDto
            {
                Id = s.Id,
                UserId = s.UserId,
                PlanName = s.PlanName,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                Status = s.Status.ToString()
            }).ToList();
        }

        public async Task<Subscription> Handle(GetSubscriptionByUserIdQuery query)
        {
            var subscription = await _repository.GetAllAsync();
            var result = subscription.FirstOrDefault(s => s.UserId == query.UserId);

            if (result == null)
            {
                throw new KeyNotFoundException($"Subscription not found for UserId: {query.UserId}");
            }

            return result;
        }
    }
}
