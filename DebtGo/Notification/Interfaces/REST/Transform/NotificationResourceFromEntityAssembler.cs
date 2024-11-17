using DebtGo.Notification.Domain.Model.Aggregates;

namespace NotificationsBC.Interfaces.REST.Transform;

public class NotificationResourceFromEntityAssembler
{
    public CreateNotificationResource ToResource(Notification notification)
    {
        return new CreateNotificationResource
        {
            Id = notification.Id,
            Content = notification.Content,
            RecipientAddress = notification.RecipientAddress,
            Type = notification.Type.ToString(),
            Category = notification.Category.ToString(),
            CreatedAt = notification.CreatedDate
        };
    }

    public IEnumerable<CreateNotificationResource> ToResourceList(IEnumerable<Notification> notifications)
    {
        return notifications.Select(ToResource);
    }
}
