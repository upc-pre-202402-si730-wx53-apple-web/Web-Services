<<<<<<< Updated upstream
<<<<<<< Updated upstream
using DebtGo.Notification.Domain.Model.Aggregates;

namespace DebtGo.Notification.Domain.Repositories;

public interface INotificationRepository
{
    Task AddAsync(NotificationAudit notification);
    Task AddAsync(Model.Aggregates.Notification notification);
    Task<NotificationAudit?> FindByIdAsync(int id);
    Task<IEnumerable<NotificationAudit>> FindByUserIdAsync(int userId);
    Task<IEnumerable<NotificationAudit>> ListAsync();
=======
<<<<<<< HEAD
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
>>>>>>> Stashed changes
=======
<<<<<<< HEAD
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
>>>>>>> Stashed changes
}
=======
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
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
