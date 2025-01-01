using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainDrivenDesign.Domain.Shared
{
    /// <summary>
    /// Represents a currency with a specific code.
    /// </summary>
    /// <remarks>
    /// Implements the Value Object pattern, ensuring immutability and equality based on the <see cref="Code"/>.
    /// </remarks>
    public sealed record Currency
    {
        /// <summary>
        /// Represents the absence of a specific currency.
        /// </summary>
        internal static readonly Currency None = new("");

        /// <summary>
        /// Represents the US Dollar currency.
        /// </summary>
        public static readonly Currency USD = new("USD");

        /// <summary>
        /// Represents the Turkish Lira currency.
        /// </summary>
        public static readonly Currency TRY = new("TRY");

        /// <summary>
        /// Gets the code of the currency.
        /// </summary>
        public string Code { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> record with the specified code.
        /// </summary>
        /// <param name="code">The currency code.</param>
        private Currency(string code)
        {
            Code = code;
        }

        /// <summary>
        /// Creates a <see cref="Currency"/> instance based on the provided code.
        /// </summary>
        /// <param name="code">The currency code.</param>
        /// <returns>A <see cref="Currency"/> instance corresponding to the provided code.</returns>
        /// <exception cref="ArgumentException">Thrown when the provided currency code is invalid.</exception>
        public static Currency FromCode(string code)
        {
            // Attempt to find a matching currency; throw an exception if not found.
            return All.FirstOrDefault(p => p.Code == code) ??
                throw new ArgumentException("Invalid currency code!");
        }

        /// <summary>
        /// Gets all predefined valid currency instances.
        /// </summary>
        public static readonly IReadOnlyCollection<Currency> All = new[] { USD, TRY };
    }
}