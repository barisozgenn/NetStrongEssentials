using DomainDrivenDesign.Domain.Users;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Users
{
    /// <summary>
    /// Defines the contract for user data access operations.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Creates a new user with the specified details.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password for the user account.</param>
        /// <param name="country">The country of the user's address.</param>
        /// <param name="city">The city of the user's address.</param>
        /// <param name="street">The street of the user's address.</param>
        /// <param name="postalCode">The postal code of the user's address.</param>
        /// <param name="fullAddress">The complete address of the user.</param>
        /// <param name="cancellationToken">
        /// A token to monitor for cancellation requests.
        /// Using cancellation tokens is especially useful in scenarios where long-running asynchronous operations need to be responsive to external events or user interactions.
        /// It allows for a graceful way to stop or interrupt an operation without leaving resources hanging or causing unnecessary delays.
        /// </param>
        /// <returns>The created <see cref="User"/> entity.</returns>
        Task<User> CreateAsync(
            string name,
            string email,
            string password,
            string country,
            string city,
            string street,
            string postalCode,
            string fullAddress,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all users from the data store.
        /// </summary>
        /// <param name="cancellationToken">
        /// A token to monitor for cancellation requests.
        /// Using cancellation tokens is especially useful in scenarios where long-running asynchronous operations need to be responsive to external events or user interactions.
        /// It allows for a graceful way to stop or interrupt an operation without leaving resources hanging or causing unnecessary delays.
        /// </param>
        /// <returns>A list of all <see cref="User"/> entities.</returns>
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}