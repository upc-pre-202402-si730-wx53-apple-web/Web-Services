namespace DebtGo.Notification.Domain.Model.Commands;

public record CreateNotificationCommand(string Content, NotificationType Type, NotificationCategory Category);
