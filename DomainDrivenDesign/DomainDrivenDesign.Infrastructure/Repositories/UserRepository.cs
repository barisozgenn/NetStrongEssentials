using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories
{
    /// <summary>
    /// Provides data access functionalities for <see cref="User"/> entities.
    /// </summary>
    /// <remarks>
    /// Implements the <see cref="IUserRepository"/> interface to handle CRUD operations for users.
    /// Utilizes <see cref="ApplicationDbContext"/> for interacting with the database.
    /// </remarks>
    internal sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The database context used for data access operations.</param>
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

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
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The created <see cref="User"/> entity.</returns>
        public async Task<User> CreateAsync(string name, string email, string password, string country, string city, string street, string postalCode, string fullAddress, CancellationToken cancellationToken = default)
        {
            // Create a new User entity using the factory method to enforce business rules and validations.
            User user = User.CreateUser(name, email, password, country, city, street, postalCode, fullAddress);

            // Add the new user to the context for insertion into the database.
            await _context.Users.AddAsync(user, cancellationToken);

            return user;
        }

        /// <summary>
        /// Retrieves all users from the data store.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A list of all <see cref="User"/> entities.</returns>
        public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            // Fetch all users from the database asynchronously.
            return _context.Users.ToListAsync(cancellationToken);
        }
    }
}