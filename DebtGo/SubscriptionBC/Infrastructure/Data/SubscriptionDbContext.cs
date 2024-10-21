using DebtGo.SubscriptionBC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebtGo.SubscriptionBC.Infrastructure.Data
{
    /// <summary>
    ///     Database context for the Subscription bounded context.
    /// </summary>
    /// <remarks>
    ///     This context is responsible for interacting with the database for the Subscription entity. 
    ///     It manages the DbSet of <see cref="Subscription"/> and provides methods for configuring
    ///     the entity mappings using the Entity Framework Core model builder.
    /// </remarks>
    public class SubscriptionDbContext : DbContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SubscriptionDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to configure the DbContext.</param>
        public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options)
            : base(options) { }

        /// <summary>
        ///     Gets or sets the DbSet of <see cref="Subscription"/>.
        /// </summary>
        public DbSet<Subscription> Subscriptions { get; set; }

        /// <summary>
        ///     Configures the entity mappings using the model builder.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure entity mappings.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>(entity =>
            {
                // Set the primary key
                entity.HasKey(e => e.Id);

                // Configure the UserId property
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                // Configure the PlanName property
                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(100);

                // Configure the Status property to store as a string
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasConversion<string>();
            });
        }
    }
}
