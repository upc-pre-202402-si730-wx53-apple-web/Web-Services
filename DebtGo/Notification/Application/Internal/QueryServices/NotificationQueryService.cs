using DebtGo.Notification.Domain.Model.Queries;
using DebtGo.Notification.Domain.Repositories;
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
using DebtGo.Notification.Domain.Services;
using NotificationAgg = DebtGo.Notification.Domain.Model.Aggregates.Notification;
=======
>>>>>>> Stashed changes
using NotificationsBC.Application.Internal.QueryServices;

>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
namespace DebtGo.Notification.Application.Internal.QueryServices;

public class NotificationQueryService : INotificationQueryService
{
<<<<<<< Updated upstream
    private readonly INotificationRepository _notificationRepository;

    public NotificationQueryService(INotificationRepository notificationRepository)
=======
<<<<<<< HEAD
    public async Task<IEnumerable<NotificationAgg>> Handle(GetAllNotificationsQuery query)
=======
    private readonly INotificationRepository _notificationRepository;

    public NotificationQueryService(INotificationRepository notificationRepository)
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
>>>>>>> Stashed changes
    {
        _notificationRepository = notificationRepository;
    }

<<<<<<< Updated upstream
    public async Task<IEnumerable<NotificationAudit>> Handle(GetAllNotificationsQuery query) =>
        await _notificationRepository.ListAsync();

=======
<<<<<<< HEAD
    public async Task<NotificationAgg?> Handle(GetNotificationByIdQuery query)
    {
        return await notificationRepository.FindByIdAsync(query.NotificationId);
    }

    /* public async Task<IEnumerable<NotificationAgg>> Handle(GetNotificationsByUserQuery query)
    {
        return await notificationRepository.FindByUserIdAsync(query.UserId);
    } */
=======
    public async Task<IEnumerable<NotificationAudit>> Handle(GetAllNotificationsQuery query) =>
        await _notificationRepository.ListAsync();

>>>>>>> Stashed changes
    public async Task<NotificationAudit?> Handle(GetNotificationByIdQuery query) =>
        await _notificationRepository.FindByIdAsync(query.NotificationId);

    public async Task<IEnumerable<NotificationAudit>> Handle(GetNotificationsByUserQuery query) =>
        await _notificationRepository.FindByUserIdAsync(query.UserId);
<<<<<<< Updated upstream
=======
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
>>>>>>> Stashed changes
}
