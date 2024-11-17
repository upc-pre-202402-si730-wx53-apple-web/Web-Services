using DebtGo.Notification.Domain.Model.Commands;

namespace DebtGo.Notification.Interfaces.REST.Transform
{
    public class NotificationCommandFromResourceAssembler
    {
        public CreateNotificationCommand ToCommand(CreateNotificationResource resource)
        {
            return new CreateNotificationCommand(resource.Content, resource.Type);
        }
    }
}
