using DebtGo.Notification.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DebtGo.Notification.Infrastructure.Persistence.EFC.Configuration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {

            builder.ToTable("Notifications");

            builder.HasKey(n => n.Id);

            builder.Property(n => n.Content.Content)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(n => n.Type)
                   .IsRequired();

            builder.Property(n => n.Category)
                   .IsRequired();

            builder.Property(n => n.Recipient.RecipientAddress)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasIndex(n => n.Recipient.RecipientAddress);
        }
    }
}
