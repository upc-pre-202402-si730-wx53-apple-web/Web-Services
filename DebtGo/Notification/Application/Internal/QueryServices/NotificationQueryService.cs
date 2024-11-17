using DebtGo.Notification.Domain.Model.Aggregates;
using DebtGo.Notification.Domain.Model.Queries;
using DebtGo.Notification.Domain.Repositories;
using NotificationsBC.Application.Internal.QueryServices;

namespace DebtGo.Notification.Application.Internal.QueryServices;

public class NotificationQueryService : INotificationQueryService
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationQueryService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<IEnumerable<NotificationAudit>> Handle(GetAllNotificationsQuery query) =>
        await _notificationRepository.ListAsync();

    public async Task<NotificationAudit?> Handle(GetNotificationByIdQuery query) =>
        await _notificationRepository.FindByIdAsync(query.NotificationId);

    public async Task<IEnumerable<NotificationAudit>> Handle(GetNotificationsByUserQuery query) =>
        await _notificationRepository.FindByUserIdAsync(query.UserId);
}
