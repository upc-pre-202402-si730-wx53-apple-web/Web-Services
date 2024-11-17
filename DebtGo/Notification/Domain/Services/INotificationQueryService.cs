using DebtGo.Notification.Domain.Model.Queries;
using NotificationAgg = DebtGo.Notification.Domain.Model.Aggregates.Notification;

namespace DebtGo.Notification.Domain.Services
{
    public interface INotificationQueryService
    {
        public Task<IEnumerable<NotificationAgg>> Handle(GetAllNotificationsQuery query);
        public Task<NotificationAgg?> Handle(GetNotificationByIdQuery query);
        /* public Task<IEnumerable<NotificationAgg>> Handle(GetNotificationsByUserQuery query); */
    }
}