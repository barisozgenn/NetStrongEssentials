using System;

namespace DomainDrivenDesign.Domain.Users
{
    /// <summary>
    /// Represents a user's password within the domain.
    /// </summary>
    /// <remarks>
    /// Implements the Value Object pattern, ensuring that passwords meet defined security requirements and are immutable.
    /// </remarks>
    public sealed record Password
    {
        /// <summary>
        /// Gets the value of the password.
        /// </summary>
        public string Value { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Password"/> record with the specified value.
        /// </summary>
        /// <param name="value">The password string.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the provided password is null, empty, or does not meet the minimum length requirement.
        /// </exception>
        public Password(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Password cannot be null or empty!");
            }

            if (value.Length < 6)
            {
                throw new ArgumentException("Password should be at least 6 characters long!");
            }

            Value = value;
        }
    }
}