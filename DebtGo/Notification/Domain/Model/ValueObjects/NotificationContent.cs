namespace DebtGo.Notification.Domain.Model.ValueObjects;

public record NotificationContent(string Content)
{
    public NotificationContent() : this(string.Empty) { }

    public string Summary => Content.Length <= 50 ? Content : Content.Substring(0, 50) + "...";
}
