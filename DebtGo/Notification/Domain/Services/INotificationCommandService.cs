using DebtGo.Notification.Domain.Model.Commands;
using NotificationAgg = DebtGo.Notification.Domain.Model.Aggregates.Notification;
namespace DebtGo.Notification.Domain.Services
{
    public interface INotificationCommandService
    {
        public Task<NotificationAgg?> Handle(CreateNotificationCommand command);
    }
}