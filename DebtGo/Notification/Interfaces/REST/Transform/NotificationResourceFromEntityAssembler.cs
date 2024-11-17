<<<<<<< Updated upstream
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
=======
<<<<<<< HEAD
using DebtGo.Notification.Interfaces.REST.Resources;

using NotificationAgg = DebtGo.Notification.Domain.Model.Aggregates.Notification;

namespace DebtGo.Notification.Interfaces.REST.Transform
=======
using DebtGo.Notification.Domain.Model.Aggregates;

namespace NotificationsBC.Interfaces.REST.Transform;

public class NotificationResourceFromEntityAssembler
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
{
    public CreateNotificationResource ToResource(Notification notification)
    {
<<<<<<< HEAD
        public static NotificationResource ToResourceFromEntity(NotificationAgg entity)
        {
            return new NotificationResource(
                entity.Content.Content,
                entity.Type.ToString(),
                entity.Status.ToString());
        }
=======
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
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
>>>>>>> Stashed changes
    }
}
