using DebtGo.IAM.Domain.Model.Aggregates;
using DebtGo.IAM.Domain.Model.Entities;
using DebtGo.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using NotificationAgg = DebtGo.Notification.Domain.Model.Aggregates.Notification;

namespace DebtGo.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TODO agregar tablas    
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();

            modelBuilder.Entity<PaymentCard>().HasKey(p => p.Id);
            modelBuilder.Entity<PaymentCard>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<PaymentCard>().Property(p => p.CardNumber).IsRequired();
            modelBuilder.Entity<PaymentCard>().Property(p => p.ExpiryDate).IsRequired();
            modelBuilder.Entity<PaymentCard>().Property(p => p.CVV).IsRequired().HasColumnName("cvv");
            modelBuilder.Entity<PaymentCard>()
                .HasOne(p => p.User)
                .WithOne(u => u.PaymentCard)
                .HasForeignKey<PaymentCard>(p => p.UserId);

            modelBuilder.Entity<NotificationAgg>().HasKey(n => n.Id);
            modelBuilder.Entity<NotificationAgg>().Property(n => n.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<NotificationAgg>().OwnsOne(n => n.Content, nc =>
            {
                nc.WithOwner().HasForeignKey("id");
                nc.Property(c => c.Content)
                      .HasColumnName("content")
                      .IsRequired();
            });
            modelBuilder.Entity<NotificationAgg>().Property(n => n.Type).IsRequired().HasConversion<string>();
            modelBuilder.Entity<NotificationAgg>().Property(n => n.Status).IsRequired().HasConversion<string>();

            modelBuilder.UseSnakeCaseNamingConvention();
        }

    }
}