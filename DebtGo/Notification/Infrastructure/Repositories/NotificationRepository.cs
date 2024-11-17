using DebtGo.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using NotificationAgg = DebtGo.Notification.Domain.Model.Aggregates.Notification;
using DebtGo.Notification.Domain.Model;
using DebtGo.Notification.Domain.Model.ValueObjects;
using DebtGo.Notification.Domain.Repositories;
using DebtGo.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DebtGo.Notification.Infrastructure.Persistence.EFC.Repositories
{
    public class NotificationRepository(AppDbContext context) : BaseRepository<NotificationAgg>(context), INotificationRepository
    {
        /* public async Task<IEnumerable<Domain.Model.Aggregates.Notification>> GetNotificationsByRecipientAsync(NotificationRecipient recipient)
        {
            return await _context.Set<Domain.Model.Aggregates.Notification>()
                                 .Where(n => n.Recipient == recipient)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Domain.Model.Aggregates.Notification>> GetNotificationsByTypeAsync(NotificationType type)
        {
            return await _context.Set<Domain.Model.Aggregates.Notification>()
                                 .Where(n => n.Type == type)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Domain.Model.Aggregates.Notification>> GetNotificationsByCategoryAsync(NotificationCategory category)
        {
            return await _context.Set<Domain.Model.Aggregates.Notification>()
                                 .Where(n => n.Category == category)
                                 .ToListAsync();
        } */
    }
}
