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
        /// 
        public static CreateSubscriptionCommand ToCommandFromResource(CreateSubscriptionResource resource)
        {
            return new CreateSubscriptionCommand(resource.UserId, resource.PlanName, resource.StartDate, resource.EndDate, resource.Status);
        }
    }
}
