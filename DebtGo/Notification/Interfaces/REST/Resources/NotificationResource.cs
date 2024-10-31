namespace DebtGo.Notification.Interfaces.REST.Resources;

public class NotificationResource
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string RecipientAddress { get; set; }
    public string Type { get; set; }
    public string Category { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
