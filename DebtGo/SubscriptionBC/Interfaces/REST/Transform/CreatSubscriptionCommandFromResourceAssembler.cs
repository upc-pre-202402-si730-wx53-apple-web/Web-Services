using DebtGo2.SubscriptionBC.Domain.Model.Commands;
using DebtGo2.SubscriptionBC.Interfaces.REST.Resources;

namespace DebtGo2.SubscriptionBC.Interfaces.REST.Transform
{
    /// <summary>
    ///     Assembles a <see cref="CreateSubscriptionCommand"/> from a <see cref="CreateSubscriptionResource"/>.
    /// </summary>
    public class CreateSubscriptionCommandFromResourceAssembler
    {
        /// <summary>
        ///     Converts a <see cref="CreateSubscriptionResource"/> into a <see cref="CreateSubscriptionCommand"/>.
        /// </summary>
        /// <param name="resource"> The subscription resource.</param>
        /// <returns> A <see cref="CreateSubscriptionCommand"/> object.</returns>
        public CreateSubscriptionCommand ToCommand(CreateSubscriptionResource resource)
        {
            return new CreateSubscriptionCommand
            {
                UserId = resource.UserId,
                PlanName = resource.PlanName,
                StartDate = resource.StartDate,
                EndDate = resource.EndDate,
                Status = resource.Status
            };
        }
    }
}
