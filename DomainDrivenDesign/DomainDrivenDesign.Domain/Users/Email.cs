using System;

namespace DomainDrivenDesign.Domain.Users
{
    /// <summary>
    /// Represents an email address within the domain.
    /// </summary>
    /// <remarks>
    /// Implements the Value Object pattern, ensuring that email addresses are valid and immutable.
    /// </remarks>
    public sealed record Email
    {
        /// <summary>
        /// Gets the value of the email address.
        /// </summary>
        public string Value { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> record with the specified value.
        /// </summary>
        /// <param name="value">The email address.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the provided email is null, empty, or does not conform to a basic email format.
        /// </exception>
        public Email(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Email cannot be empty!");
            }
            if (!value.Contains("@") || !value.Contains("."))
            {
                throw new ArgumentException("Email format is not correct!");
            }

            Value = value;
        }
    }
}