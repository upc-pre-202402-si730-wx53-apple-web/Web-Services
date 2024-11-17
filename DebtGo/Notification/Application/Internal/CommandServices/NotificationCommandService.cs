using DebtGo.Notification.Domain.Model.Aggregates;
using DebtGo.Notification.Domain.Model.Commands;
using DebtGo.Notification.Domain.Repositories;

namespace NotificationsBC.Application.Internal.CommandServices;

public class NotificationCommandService : INotificationCommandService
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationCommandService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<Notification> Handle(CreateNotificationCommand command)
    {
        var notification = new Notification(command.Content, command.Type);
        await _notificationRepository.AddAsync(notification);
        return notification;
    }

    Task<Notification> INotificationCommandService.Handle(CreateNotificationCommand command)
    {
        throw new NotImplementedException();
    }
}
