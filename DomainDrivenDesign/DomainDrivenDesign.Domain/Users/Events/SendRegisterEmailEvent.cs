using MediatR;
using DomainDrivenDesign.Domain.Users.Events;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Users.Events
{
    /// <summary>
    /// Handles the <see cref="UserDomainEvent"/> by sending a registration email.
    /// </summary>
    /// <remarks>
    /// Implements <see cref="INotificationHandler{TNotification}"/> to process domain events through MediatR.
    /// </remarks>
    public sealed class SendRegisterEmailEvent : INotificationHandler<UserDomainEvent>
    {
        /// <summary>
        /// Handles the <see cref="UserDomainEvent"/> by sending a registration email to the user.
        /// </summary>
        /// <param name="notification">The domain event containing user details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A completed task.</returns>
        public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Implement email sending logic here.
            return Task.CompletedTask;
        }
    }
}