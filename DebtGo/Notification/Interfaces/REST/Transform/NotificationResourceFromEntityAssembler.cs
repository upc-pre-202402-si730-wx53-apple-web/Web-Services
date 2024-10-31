using DebtGo.Notification.Domain.Model.Aggregates;
using DebtGo.Notification.Interfaces.REST.Resources;

namespace DebtGo.Notification.Interfaces.REST.Transform
{
    public class NotificationResourceFromEntityAssembler
    {
        public NotificationResource ToResource(Notification notification)
        {
            return new NotificationResource
            {
                Id = notification.Id,
                Content = notification.Content.Content,
                RecipientAddress = notification.Recipient.RecipientAddress,
                Type = notification.Type.ToString(),
                Category = notification.Category.ToString(),
                CreatedAt = notification.CreatedDate
            };
        }

        public IEnumerable<NotificationResource> ToResourceList(IEnumerable<Notification> notifications)
        {
            return notifications.Select(ToResource);
        }
    }
}
