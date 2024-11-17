<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
<<<<<<< HEAD
using DebtGo.Shared.Domain.Repositories;
using NotificationAgg = DebtGo.Notification.Domain.Model.Aggregates.Notification;
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
using DebtGo.Notification.Domain.Model.Aggregates;
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
using DebtGo.Notification.Domain.Model.Commands;
using DebtGo.Notification.Domain.Repositories;

namespace NotificationsBC.Application.Internal.CommandServices;

public class NotificationCommandService : INotificationCommandService
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    private readonly INotificationRepository _notificationRepository;

    public NotificationCommandService(INotificationRepository notificationRepository)
    {
=======
<<<<<<< HEAD
    public async Task<NotificationAgg?> Handle(CreateNotificationCommand command)
    {
=======
<<<<<<< HEAD
    public async Task<NotificationAgg?> Handle(CreateNotificationCommand command)
    {
>>>>>>> Stashed changes
        var notification = new NotificationAgg(command);
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
=======
    private readonly INotificationRepository _notificationRepository;

    public NotificationCommandService(INotificationRepository notificationRepository)
    {
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
>>>>>>> Stashed changes
=======
>>>>>>> 4a1c21b94a3a9bcb561ee28a24c061c232d90ba0
>>>>>>> Stashed changes
    }
}
