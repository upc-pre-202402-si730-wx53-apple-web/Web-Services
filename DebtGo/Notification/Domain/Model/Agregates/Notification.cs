using DebtGo.Notification.Domain.Model.Commands;
using DebtGo.Notification.Domain.Model.ValueObjects;

namespace DebtGo.Notification.Domain.Model.Aggregates;

public partial class Notification
{
    public Notification()
    {
        Content = new NotificationContent();
        //Content = string.Empty;
        Type = NotificationType.Email;
        Status = NotificationStatus.Pending;
    }

    public Notification(string content, NotificationType type, NotificationStatus status)
    {
        Content = new NotificationContent(content);
        //Content = content;
        Type = type;
        Status = status;
    }

    public Notification(CreateNotificationCommand command)
    {
        Content = new NotificationContent(command.Content);
        //Content = command.Content;

        if (!Enum.IsDefined(typeof(NotificationType), command.Type))
            throw new Exception("Status must be a valid value (Email, SMS, PushNotification).");

        switch (command.Type)
        {
            case "Email":
                Type = NotificationType.Email;
                break;

            case "SMS":
                Type = NotificationType.SMS;
                break;

            case "PushNotification":
                Type = NotificationType.PushNotification;
                break;

            default:
                break;
        }


        Status = NotificationStatus.Pending;
    }

    public int Id { get; }
    public NotificationContent Content { get; private set; }
    public NotificationType Type { get; private set; }
    public NotificationStatus Status { get; private set; }

    public void MarkAsSent()
    {
        Status = NotificationStatus.Sent;
    }

    public void MarkAsFailed()
    {
        Status = NotificationStatus.Failed;
    }
}
