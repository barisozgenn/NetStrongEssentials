using MediatR;
using DomainDrivenDesign.Domain.Users;

namespace DomainDrivenDesign.Domain.Users.Events
{
    /// <summary>
    /// Represents a domain event that occurs when a user is created.
    /// </summary>
    /// <remarks>
    /// Implements <see cref="INotification"/> to enable publishing through MediatR.
    /// </remarks>
    public sealed class UserDomainEvent : INotification
    {
        /// <summary>
        /// Gets the user associated with this event.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDomainEvent"/> class with the specified user.
        /// </summary>
        /// <param name="user">The user that was created.</param>
        public UserDomainEvent(User user)
        {
            User = user;
        }
    }
}