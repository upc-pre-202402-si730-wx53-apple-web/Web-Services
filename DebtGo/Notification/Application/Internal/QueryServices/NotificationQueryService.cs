using DebtGo.Notification.Domain.Model.Aggregates;
using DebtGo.Notification.Domain.Model.Queries;
using DebtGo.Notification.Domain.Repositories;
using DebtGo.Notification.Domain.Services;

namespace DebtGo.Notification.Application.Internal.QueryServices;

public class NotificationQueryService(INotificationRepository notificationRepository) : INotificationQueryService
{
    public async Task<IEnumerable<Notification>> Handle(GetAllNotificationsQuery query)
    {
        return await notificationRepository.ListAsync();
    }

    public async Task<Notification?> Handle(GetNotificationByIdQuery query)
    {
        return await notificationRepository.FindByIdAsync(query.NotificationId);
    }

    public async Task<IEnumerable<Notification>> Handle(GetNotificationsByUserQuery query)
    {
        return await notificationRepository.FindByUserIdAsync(query.UserId);
    }
}
