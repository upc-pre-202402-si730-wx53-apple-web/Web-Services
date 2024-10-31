using DebtGo.Notification.Domain.Model.Commands;
using DebtGo.Notification.Interfaces.REST.Resources;

namespace DebtGo.Notification.Interfaces.REST.Transform
{
    public class NotificationCommandFromResourceAssembler
    {
        public CreateNotificationCommand ToCommand(CreateNotificationResource resource)
        {
            return new CreateNotificationCommand(
                resource.Content,
                resource.RecipientAddress,
                resource.Type,
                resource.Category
            );
        }
    }
}
