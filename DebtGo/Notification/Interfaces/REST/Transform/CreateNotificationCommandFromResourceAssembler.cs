using DebtGo.Notification.Domain.Model.Commands;
using DebtGo.Notification.Interfaces.REST.Resources;

namespace DebtGo.Notification.Interfaces.REST.Transform
{
    public class CreateNotificationCommandFromResourceAssembler
    {
        public static CreateNotificationCommand ToCommandFromResource(CreateNotificationResource resource)
        {
            var type = resource.Type.ToUpper();

            if (!string.Equals(type, "EMAIL")
                && !string.Equals(type, "SMS")
                && !string.Equals(type, "PUSHNOTIFICATION"))
                throw new Exception("Type must be a valid value (Email, SMS, PushNotification).");


            return new CreateNotificationCommand(
                resource.Content,
                type,
                resource.Category);
        }
    }
}