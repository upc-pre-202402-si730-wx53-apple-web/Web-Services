using System.ComponentModel.DataAnnotations.Schema;
using DebtGo.Notification.Domain.Model.Commands;
using DebtGo.Notification.Domain.Model.ValueObjects;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace DebtGo.Notification.Domain.Model.Aggregates;

public partial class Notification
{
    public Notification()
    {
        Content = new NotificationContent();
        Type = NotificationType.Email;
        Status = NotificationStatus.Pending;
    }

    public Notification(string content, NotificationType type, NotificationStatus status)
    {
        Content = new NotificationContent(content);
        Type = type;
        Status = status;
    }

    public Notification(CreateNotificationCommand command)
    {
        Content = new NotificationContent(command.Content);
        Type = command.Type;
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
