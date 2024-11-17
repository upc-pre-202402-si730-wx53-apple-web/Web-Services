using DebtGo.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using DebtGo2.SubscriptionBC.Domain.Model.Aggregates;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<Subscription>(entity =>
                      {
                          entity.HasKey(e => e.Id);

                          entity.Property(e => e.UserId)
                              .IsRequired()
                              .HasMaxLength(50);

                          entity.Property(e => e.PlanName)
                              .HasMaxLength(100);

                          entity.Property(e => e.Status)
                              .IsRequired()
                              .HasConversion<string>();
                      });


            modelBuilder.UseSnakeCaseNamingConvention();
        }

    }
}