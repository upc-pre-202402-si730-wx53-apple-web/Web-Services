using DebtGo.Shared.Domain.Repositories;
using DebtGo.Notification.Domain.Model.Aggregates;
using DebtGo.Notification.Domain.Model.ValueObjects;

namespace DebtGo.Notification.Domain.Repositories;

public interface INotificationRepository : IBaseRepository<Notification>
{
    Task<IEnumerable<Notification>> GetNotificationsByRecipientAsync(NotificationRecipient recipient);
    Task<IEnumerable<Notification>> GetNotificationsByTypeAsync(NotificationType type);
    Task<IEnumerable<Notification>> GetNotificationsByCategoryAsync(NotificationCategory category);
}
