using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Shared;
using System;

namespace DomainDrivenDesign.Domain.Users
{
    /// <summary>
    /// Represents a user within the domain.
    /// </summary>
    /// <remarks>
    /// A <see cref="User"/> aggregates properties like name, email, password, and address.
    /// Implements the <see cref="Entity"/> base class to inherit the unique identifier.
    /// Utilizes the Factory Method pattern to control object creation and enforce business rules.
    /// </remarks>
    public sealed class User : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the user.</param>
        private User(Guid id) : base(id)
        {
            // Private constructor to enforce the use of the factory method for object creation.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class with the specified details.
        /// </summary>
        /// <param name="id">The unique identifier for the user.</param>
        /// <param name="name">The name of the user.</param>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="address">The physical address of the user.</param>
        private User(Guid id, Name name, Email email, Password password, Address address) : base(id)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        public Name Name { get; private set; }

        /// <summary>
        /// Gets the email address of the user.
        /// </summary>
        public Email Email { get; private set; }

        /// <summary>
        /// Gets the password of the user.
        /// </summary>
        public Password Password { get; private set; }

        /// <summary>
        /// Gets the physical address of the user.
        /// </summary>
        public Address Address { get; private set; }

        /// <summary>
        /// Creates a new <see cref="User"/> instance with the specified details.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="email">The email address of the user.</param>
        /// <param name="password">The password for the user account.</param>
        /// <param name="country">The country of the user's address.</param>
        /// <param name="city">The city of the user's address.</param>
        /// <param name="street">The street of the user's address.</param>
        /// <param name="postalCode">The postal code of the user's address.</param>
        /// <param name="fullAddress">The complete address of the user.</param>
        /// <returns>A new <see cref="User"/> instance.</returns>
        /// <remarks>
        /// The factory method simplifies object creation by encapsulating the details and applying necessary business rules.
        /// </remarks>
        public static User CreateUser(
            string name,
            string email,
            string password,
            string country,
            string city,
            string street,
            string postalCode,
            string fullAddress)
        {
            // Apply business rules as necessary.

            // Create a new user instance with validated and encapsulated data.
            User user = new(
                id: Guid.NewGuid(),
                name: new(name),
                email: new(email),
                password: new(password),
                address: new(country, city, street, fullAddress, postalCode));

            return user;
        }

        /// <summary>
        /// Changes the name of the user.
        /// </summary>
        /// <param name="name">The new name for the user.</param>
        public void ChangeName(string name)
        {
            Name = new(name);
        }

        /// <summary>
        /// Changes the address of the user.
        /// </summary>
        /// <param name="country">The new country of the user's address.</param>
        /// <param name="city">The new city of the user's address.</param>
        /// <param name="street">The new street of the user's address.</param>
        /// <param name="postalCode">The new postal code of the user's address.</param>
        /// <param name="fullAddress">The new complete address of the user.</param>
        public void ChangeAddress(string country, string city, string street, string postalCode, string fullAddress)
        {
            Address = new(country, city, street, fullAddress, postalCode);
        }

        /// <summary>
        /// Changes the email address of the user.
        /// </summary>
        /// <param name="email">The new email address for the user.</param>
        public void ChangeEmail(string email)
        {
            Email = new(email);
        }

        /// <summary>
        /// Changes the password of the user.
        /// </summary>
        /// <param name="password">The new password for the user account.</param>
        public void ChangePassword(string password)
        {
            Password = new(password);
        }
    }
}