using DebtGo.Shared.Domain.Repositories;
using NotificationAgg = DebtGo.Notification.Domain.Model.Aggregates.Notification;
using DebtGo.Notification.Domain.Model.Commands;
using DebtGo.Notification.Domain.Repositories;
using DebtGo.Notification.Domain.Services;

namespace NotificationsBC.Application.Internal.CommandServices;

public class NotificationCommandService(
        INotificationRepository notificationRepository,
        IUnitOfWork unitOfWork) : INotificationCommandService
{
    public async Task<NotificationAgg> Handle(CreateNotificationCommand command)
    {
        var notification = new NotificationAgg(command);
        await notificationRepository.AddAsync(notification);
        await unitOfWork.CompleteAsync();
        return notification;
    }
}
