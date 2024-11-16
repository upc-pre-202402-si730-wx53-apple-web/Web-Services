using Microsoft.EntityFrameworkCore;
using DebtGo2.SubscriptionBC.Domain.Model.Aggregates;

namespace DebtGo.SubscriptionBC.Infrastructure.Data
{
    /// <summary>
    ///     Represents the database context for subscription entities.
    /// </summary>
    public class SubscriptionDbContext : DbContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SubscriptionDbContext"/> class.
        /// </summary>
        /// <param name="options"> The options to configure the database context.</param>
        public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options)
            : base(options) { }

        /// <summary>
        ///     Gets or sets the subscriptions table.
        /// </summary>
        public DbSet<Subscription> Subscriptions { get; set; }

        /// <summary>
        ///     Configures the model for the database context.
        /// </summary>
        /// <param name="modelBuilder"> The model builder used to configure entity mappings.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("Subscription"); // Specifies the exact table name
                entity.HasKey(e => e.Id);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasConversion<string>();
            });
        }
    }
}
