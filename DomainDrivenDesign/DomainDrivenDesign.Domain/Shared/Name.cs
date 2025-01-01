using System;

namespace DomainDrivenDesign.Domain.Shared
{
    /// <summary>
    /// Represents a validated name within the domain.
    /// </summary>
    /// <remarks>
    /// Implements the Value Object pattern, ensuring that names adhere to business rules such as non-emptiness and minimum length.
    /// Used across multiple entities like categories, products, and users.
    /// </remarks>
    public sealed record Name
    {
        /// <summary>
        /// Gets the value of the name.
        /// </summary>
        /// <remarks>
        /// The 'init' accessor ensures that the <see cref="Value"/> can only be set during object initialization, promoting immutability.
        /// </remarks>
        public string Value { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Name"/> record with the specified value.
        /// </summary>
        /// <param name="value">The value of the name.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the provided name is null, empty, or does not meet the minimum length requirement.
        /// </exception>
        public Name(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty!");
            }
            if (value.Length < 2)
            {
                throw new ArgumentException("Name cannot be less than 3 characters!");
            }
            Value = value;
        }
    }
}