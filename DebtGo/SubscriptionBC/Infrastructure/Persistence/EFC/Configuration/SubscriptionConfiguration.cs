using DebtGo2.SubscriptionBC.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DebtGo2.SubscriptionBC.Infrastructure.Persistence.EFC.Configuration
{
    /// <summary>
    ///     Configuration class for the <see cref="Subscription"/> entity.
    /// </summary>
    /// <remarks>
    ///     This class can be used to define the configuration settings for the 
    ///     <see cref="Subscription"/> entity when it is mapped to a database context.
    ///     It ensures that the properties are correctly mapped and constraints are respected.
    /// </remarks>
    public class SubscriptionConfiguration
    {
        /// <summary>
        ///     Configures the <see cref="Subscription"/> entity's mappings.
        /// </summary>
        /// <param name="builder"> The entity type builder for <see cref="Subscription"/>.</param>
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            // Set the primary key
            builder.HasKey(s => s.Id);

            // Configure property constraints
            builder.Property(s => s.UserId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.PlanName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.StartDate)
                .IsRequired();

            builder.Property(s => s.Status)
                .IsRequired()
                .HasConversion<string>(); // Store enum as string
        }
    }
}
