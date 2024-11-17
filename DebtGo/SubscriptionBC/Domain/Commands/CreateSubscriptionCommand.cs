using DebtGo2.SubscriptionBC.Interfaces.REST.Resources;

namespace DebtGo2.SubscriptionBC.Domain.Model.Commands
{
    /// <summary>
    /// Represents a command to create a new subscription.
    /// </summary>
    public class CreateSubscriptionCommand
    {
        private string planName;
        private DateTime? endDate;

        public string UserId { get; }
        public string PlanId { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string Status { get; }

        public CreateSubscriptionCommand(string userId, string planId, DateTime startDate, DateTime endDate, string status)
        {
            UserId = userId;
            PlanId = planId;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }

        public CreateSubscriptionCommand(string userId, string planName, DateTime startDate, DateTime? endDate, string status)
        {
            UserId = userId;
            this.planName = planName;
            StartDate = startDate;
            this.endDate = endDate;
            Status = status;
        }

        public CreateSubscriptionCommand ToCommand(CreateSubscriptionResource resource)
        {
            return new CreateSubscriptionCommand(
                resource.UserId,
                resource.PlanName,
                resource.StartDate,
                resource.EndDate,
                resource.Status
            );
        }

    }
}
