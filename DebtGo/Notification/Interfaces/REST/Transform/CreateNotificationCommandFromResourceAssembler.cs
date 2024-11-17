using DebtGo.Notification.Domain.Model.Commands;
using DebtGo.Notification.Interfaces.REST.Resources;

namespace DebtGo.Notification.Interfaces.REST.Transform
{
    public class CreateNotificationCommandFromResourceAssembler
    {
        public static CreateNotificationCommand ToCommandFromResource(CreateNotificationResource resource)
        {
            if (resource.Type.ToUpper() != "EMAIL"
                || resource.Type.ToUpper() != "SMS"
                || resource.Type.ToUpper() != "PUSHNOTIFICATION")
                throw new Exception("Status must be a valid value (Email, SMS, PushNotification).");


            return new CreateNotificationCommand(
                resource.Content,
                resource.Type,
                resource.Category);
        }
    }
}