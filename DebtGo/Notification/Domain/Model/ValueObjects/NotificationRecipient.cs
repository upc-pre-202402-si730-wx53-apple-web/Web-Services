namespace DebtGo.Notification.Domain.Model.ValueObjects;

public record NotificationRecipient(string RecipientAddress)
{
    public NotificationRecipient() : this(string.Empty) { }


}
