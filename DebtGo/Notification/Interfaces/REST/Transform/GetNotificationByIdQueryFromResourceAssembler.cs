using DebtGo.Notification.Domain.Model.Queries;
using DebtGo.Notification.Interfaces.REST.Resources;

namespace DebtGo.Notification.Interfaces.REST.Transform
{
    public class GetNotificationByIdQueryFromResourceAssembler
    {
        public static GetNotificationByIdQuery ToCommandFromResource(int resource)
        {
            return new GetNotificationByIdQuery(resource);
        }
    }
}