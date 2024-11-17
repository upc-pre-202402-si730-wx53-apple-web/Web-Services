using DebtGo.Notification.Domain.Model.Aggregates;

namespace DebtGo.Notification.Domain.Repositories;

public interface INotificationRepository
{
    Task AddAsync(NotificationAudit notification);
    Task AddAsync(Model.Aggregates.Notification notification);
    Task<NotificationAudit?> FindByIdAsync(int id);
    Task<IEnumerable<NotificationAudit>> FindByUserIdAsync(int userId);
    Task<IEnumerable<NotificationAudit>> ListAsync();
}
