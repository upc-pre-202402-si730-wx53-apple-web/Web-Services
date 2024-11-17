using DebtGo.Shared.Domain.Repositories;
using DebtGo.Notification.Domain.Model.ValueObjects;
using DebtGo.Notification.Domain.Model;
using NotificationAgg = DebtGo.Notification.Domain.Model.Aggregates.Notification;

namespace DebtGo.Notification.Domain.Repositories;

public interface INotificationRepository : IBaseRepository<NotificationAgg>
{
    /* Task<IEnumerable<Model.Aggregates.Notification>> GetNotificationsByRecipientAsync(NotificationRecipient recipient);
    Task<IEnumerable<Model.Aggregates.Notification>> GetNotificationsByTypeAsync(NotificationType type);
    Task<IEnumerable<Model.Aggregates.Notification>> GetNotificationsByCategoryAsync(NotificationCategory category); */
}
