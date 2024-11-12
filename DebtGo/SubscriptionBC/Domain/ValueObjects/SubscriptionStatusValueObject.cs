namespace DebtGo2.SubscriptionBC.Domain.Model.ValueObjects
{
    /// <summary>
    ///     Represents a value object for the subscription status.
    /// </summary>
    public class SubscriptionStatusValueObject
    {
        private static readonly string[] ValidStatuses = { "Active", "Inactive", "Cancelled" };

        /// <summary>
        ///     Value of the subscription status.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SubscriptionStatusValueObject"/> class.
        /// </summary>
        /// <param name="value"> The status value.</param>
        /// <exception cref="ArgumentException"> Thrown when the status is invalid.</exception>
        public SubscriptionStatusValueObject(string value)
        {
            if (!ValidStatuses.Contains(value))
            {
                throw new ArgumentException($"Invalid subscription status: {value}");
            }

            Value = value;
        }

        /// <summary>
        ///     Returns the value of the status as a string.
        /// </summary>
        /// <returns> The status value.</returns>
        public override string ToString() => Value;
    }
}
