using DebtGo.Notification.Domain.Model.Queries;
using DebtGo.Notification.Domain.Repositories;
using DebtGo.Notification.Domain.Services;
using DebtGo.Shared.Domain.Repositories;
using NotificationAgg = DebtGo.Notification.Domain.Model.Aggregates.Notification;

namespace DebtGo.Notification.Application.Internal.QueryServices;

public class NotificationQueryService(
        INotificationRepository notificationRepository,
        IUnitOfWork unitOfWork) : INotificationQueryService
{

    public async Task<NotificationAgg?> Handle(GetNotificationByIdQuery query)
    {
        return await notificationRepository.FindByIdAsync(query.NotificationId);
    }

    public async Task<IEnumerable<NotificationAgg>> Handle(GetAllNotificationsQuery query)
    {
        return await notificationRepository.ListAsync();
    }
}
