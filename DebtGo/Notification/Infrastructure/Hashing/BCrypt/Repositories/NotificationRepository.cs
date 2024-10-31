using DebtGo.Shared.Infrastructure.Persistence.EFC.Repositories;
using DebtGo.Notification.Domain.Model.Aggregates;
using DebtGo.Notification.Domain.Repositories;
using DebtGo.Notification.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DebtGo.Notification.Infrastructure.Persistence.EFC.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        private readonly DbContext _context;

        public NotificationRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByRecipientAsync(NotificationRecipient recipient)
        {
            return await _context.Set<Notification>()
                                 .Where(n => n.Recipient == recipient)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByTypeAsync(NotificationType type)
        {
            return await _context.Set<Notification>()
                                 .Where(n => n.Type == type)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByCategoryAsync(NotificationCategory category)
        {
            return await _context.Set<Notification>()
                                 .Where(n => n.Category == category)
                                 .ToListAsync();
        }
    }
}
