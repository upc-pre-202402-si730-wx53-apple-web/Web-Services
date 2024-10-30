using DebtGo.Notification.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DebtGo.Notification.Infrastructure.Persistence.EFC.Configuration
{
    public class AuditConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {

            builder.Property(n => n.CreatedDate)
                   .HasColumnName("CreatedAt")
                   .IsRequired();

            builder.Property(n => n.UpdateDate)
                   .HasColumnName("UpdatedAt")
                   .IsRequired(false);

            builder.HasIndex(n => n.CreatedDate);
        }
    }
}
