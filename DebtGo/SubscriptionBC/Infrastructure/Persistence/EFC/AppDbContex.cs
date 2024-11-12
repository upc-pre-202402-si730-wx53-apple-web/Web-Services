using Microsoft.EntityFrameworkCore;
using DebtGo2.SubscriptionBC.Domain.Model.Aggregates;

namespace DebtGo2.SubscriptionBC.Infrastructure.Persistence.EFC
{
    /// <summary>
    ///     Represents the application database context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options"> The options to configure the database context.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        ///     Gets or sets the subscriptions table.
        /// </summary>
        public DbSet<Subscription> Subscriptions { get; set; }

        /// <summary>
        ///     Configures the model for the database context using the assembly configurations.
        /// </summary>
        /// <param name="modelBuilder"> The model builder used to apply configurations.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
