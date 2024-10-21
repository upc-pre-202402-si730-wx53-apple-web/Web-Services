using DebtGo.SubscriptionBC.Application.DTOs;
using DebtGo.SubscriptionBC.Application.Interfaces;
using DebtGo.SubscriptionBC.Domain.Entities;
using DebtGo.SubscriptionBC.Domain.Enums;
using DebtGo.SubscriptionBC.Domain.Events;
using DebtGo.SubscriptionBC.Infrastructure.Repositories;

namespace DebtGo.SubscriptionBC.Application.Services
{
    /// <summary>
    ///     Service class that implements subscription management operations.
    /// </summary>
    /// <remarks>
    ///     This class provides CRUD operations for subscriptions and triggers events upon subscription creation.
    /// </remarks>
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _repository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SubscriptionService"/> class.
        /// </summary>
        /// <param name="repository">The repository used for accessing subscription data.</param>
        public SubscriptionService(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        ///     Retrieves a subscription by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the subscription.</param>
        /// <returns>A <see cref="SubscriptionDto"/> containing the subscription details.</returns>
        public async Task<SubscriptionDto> GetSubscriptionByIdAsync(int id)
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
        /// <returns>An <see cref="IEnumerable{SubscriptionDto}"/> containing all subscriptions.</returns>
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

        /// <summary>
        ///     Creates a new subscription.
        /// </summary>
        /// <param name="dto">The <see cref="SubscriptionDto"/> containing the subscription details.</param>
        public async Task CreateSubscriptionAsync(SubscriptionDto dto)
        {
            var subscription = new Subscription
            {
                UserId = dto.UserId,
                PlanName = dto.PlanName,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Status = Enum.Parse<SubscriptionStatus>(dto.Status)
            };

            await _repository.AddAsync(subscription);

            // Trigger subscription created event
            var subscriptionCreatedEvent = new SubscriptionCreatedEvent(
                subscription.Id, subscription.UserId, subscription.PlanName, subscription.StartDate);
        }

        /// <summary>
        ///     Updates an existing subscription.
        /// </summary>
        /// <param name="dto">The <see cref="SubscriptionDto"/> containing updated subscription details.</param>
        public async Task UpdateSubscriptionAsync(SubscriptionDto dto)
        {
            var subscription = new Subscription
            {
                Id = dto.Id,
                UserId = dto.UserId,
                PlanName = dto.PlanName,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Status = Enum.Parse<SubscriptionStatus>(dto.Status)
            };

            await _repository.UpdateAsync(subscription);
        }

        /// <summary>
        ///     Deletes a subscription by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the subscription to delete.</param>
        public async Task DeleteSubscriptionAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
