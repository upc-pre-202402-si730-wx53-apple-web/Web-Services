using DebtGo.Notification.Interfaces.REST.Resources;

using NotificationAgg = DebtGo.Notification.Domain.Model.Aggregates.Notification;

namespace DebtGo.Notification.Interfaces.REST.Transform
{
    public class NotificationResourceFromEntityAssembler
    {
        public static NotificationResource ToResourceFromEntity(NotificationAgg entity)
        {
            return new NotificationResource(
                entity.Content.Content,
                entity.Type.ToString(),
                entity.Status.ToString());
        }
    }

}
