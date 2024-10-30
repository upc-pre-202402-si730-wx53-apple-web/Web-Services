namespace DebtGo.Notification.Domain.Model;

public enum NotificationType
{
    Email,
    SMS,
    PushNotification
}

public enum NotificationCategory
{
    NewService,
    Message,
    SystemAlert
}
