using System.ComponentModel.DataAnnotations;
using DebtGo.SubscriptionBC.Interface.Resources;

namespace DebtGo.SubscriptionBC.Interface.Resources
{
    /// <summary>
    ///     Data Transfer Object (DTO) for subscriptions.
    /// </summary>
    /// <remarks>
    ///     This class defines the structure for subscription-related data, which is used for communication
    ///     between different parts of the application, such as services and controllers.
    /// </remarks>
    public class SubscriptionDto
    {
        /// <summary>
        ///     Gets or sets the unique identifier of the subscription.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the unique identifier of the user associated with the subscription.
        /// </summary>
        /// <remarks>
        ///     This property is required and has a maximum length of 50 characters.
        /// </remarks>
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the subscription plan.
        /// </summary>
        /// <remarks>
        ///     This property is required and has a maximum length of 100 characters.
        /// </remarks>
        [Required]
        [StringLength(100)]
        public string PlanName { get; set; }

        /// <summary>
        ///     Gets or sets the start date of the subscription.
        /// </summary>
        /// <remarks>
        ///     This property is required and represents the date when the subscription became active.
        /// </remarks>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the end date of the subscription, if applicable.
        /// </summary>
        /// <remarks>
        ///     This property is optional and may be null for ongoing subscriptions.
        /// </remarks>
        public DateTime? EndDate { get; set; }

        /// <summary>
        ///     Gets or sets the status of the subscription.
        /// </summary>
        /// <remarks>
        ///     This property is required and indicates the current state of the subscription (e.g., Active, Inactive).
        /// </remarks>
        [Required]
        public string Status { get; set; }
    }
}
