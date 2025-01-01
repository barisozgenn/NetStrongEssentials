using System;

namespace DomainDrivenDesign.Domain.Shared
{
    /// <summary>
    /// Represents a monetary value with a specific currency.
    /// </summary>
    /// <remarks>
    /// Implements the Value Object pattern, ensuring immutability and equality based on <see cref="Amount"/> and <see cref="Currency"/>.
    /// </remarks>
    public sealed record Money(decimal Amount, Currency Currency)
    {
        /// <summary>
        /// Defines the addition operation for two <see cref="Money"/> instances.
        /// </summary>
        /// <param name="a">The first <see cref="Money"/> instance.</param>
        /// <param name="b">The second <see cref="Money"/> instance.</param>
        /// <returns>A new <see cref="Money"/> instance representing the sum.</returns>
        /// <exception cref="ArgumentException">Thrown when attempting to add two <see cref="Money"/> instances with different currencies.</exception>
        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentException("Cannot add values with different currencies!");
            }

            return new(a.Amount + b.Amount, a.Currency);
        }

        /// <summary>
        /// Creates a <see cref="Money"/> instance with zero amount and no specific currency.
        /// </summary>
        /// <returns>A <see cref="Money"/> instance representing zero amount.</returns>
        public static Money Zero() => new(0, Currency.None);

        /// <summary>
        /// Creates a <see cref="Money"/> instance with zero amount and a specified currency.
        /// </summary>
        /// <param name="currency">The currency for the zero amount.</param>
        /// <returns>A <see cref="Money"/> instance representing zero amount in the specified currency.</returns>
        public static Money Zero(Currency currency) => new(0, currency);

        /// <summary>
        /// Determines whether the current <see cref="Money"/> instance represents a zero amount.
        /// </summary>
        /// <returns><c>true</c> if the amount is zero; otherwise, <c>false</c>.</returns>
        public bool IsZero() => this == Zero(Currency);
    }
}