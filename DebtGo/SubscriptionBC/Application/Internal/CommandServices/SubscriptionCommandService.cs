using DebtGo.SubscriptionBC.Interface.Resources;
using DebtGo.SubscriptionBC.Domain.Services;
using DebtGo2.SubscriptionBC.Domain.Model.Enums;
using DebtGo2.SubscriptionBC.Infrastructure.Persistence.EFC.Repositories;
using DebtGo2.SubscriptionBC.Domain.Model.Aggregates;
using DebtGo2.SubscriptionBC.Domain.Model.Events;
using DebtGo2.SubscriptionBC.Domain.Model.Commands;

namespace DebtGo2.SubscriptionBC.Application.Internal.CommandServices
{
    /// <summary>
    ///     Implements the command service for subscription management.
    /// </summary>
    public class SubscriptionCommandService : ISubscriptionCommandService
    {
        private readonly ISubscriptionRepository _repository;

        /// <summary>
        ///     Initializes a new instance of <see cref="SubscriptionCommandService"/>.
        /// </summary>
        /// <param name="repository"> The repository used to manage subscriptions in the database.</param>
        public SubscriptionCommandService(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        ///     Creates a new subscription.
        /// </summary>
        /// <param name="dto"> The subscription data transfer object containing the details of the subscription.</param>
        public async Task CreateSubscriptionAsync(SubscriptionDto dto)
        {
            if (!Enum.TryParse<SubscriptionStatus>(dto.Status, out var status))
            {
                throw new ArgumentException($"Invalid status value: {dto.Status}");
            }

            var subscription = new Subscription
            {
                UserId = dto.UserId,
                PlanName = dto.PlanName,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Status = status
            };

            await _repository.AddAsync(subscription);

            var subscriptionCreatedEvent = new SubscriptionCreatedEvent(
                subscription.Id, subscription.UserId, subscription.PlanName, subscription.StartDate);
        }

        /// <summary>
        ///     Updates an existing subscription.
        /// </summary>
        /// <param name="dto"> The subscription data transfer object with updated details.</param>
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
        /// <param name="id"> The unique identifier of the subscription to be deleted.</param>
        public async Task DeleteSubscriptionAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Subscription> Handle(CreateSubscriptionCommand command)
        {
            if (!Enum.TryParse<SubscriptionStatus>(command.Status, out var status))
            {
                throw new ArgumentException($"Invalid status value: {command.Status}");
            }

            var subscription = new Subscription
            {
                UserId = command.UserId,
                PlanName = command.PlanId,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                Status = status
            };

            await _repository.AddAsync(subscription);
            return subscription; // Retorna la entidad completa
        }
    }
}
