using DebtGo.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using DebtGo.Shared.Domain.Repositories;
using DebtGo.Notification.Domain.Model.Aggregates;
using DebtGo.Notification.Domain.Model.Commands;
using DebtGo.Notification.Domain.Repositories;
using DebtGo.Notification.Domain.Services;

namespace DebtGo.Notification.Application.Internal.CommandServices;

public class NotificationCommandService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork) : INotificationCommandService
{
    public async Task<Notification?> Handle(CreateNotificationCommand command)
    {
        var notification = new Notification(command);
        try
        {
            await notificationRepository.AddAsync(notification);
            await unitOfWork.CompleteAsync();
            return notification;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the notification: {e.Message}");
            return null;
        }
    }
}
