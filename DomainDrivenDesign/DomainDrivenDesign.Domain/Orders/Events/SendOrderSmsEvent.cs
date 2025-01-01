using MediatR;

namespace DomainDrivenDesign.Domain.Orders.Events
{
    /// <summary>
    /// Handles the <see cref="OrderDomainEvent"/> by sending an SMS notification.
    /// </summary>
    /// <remarks>
    /// Implements <see cref="INotificationHandler{TNotification}"/> to process domain events through MediatR.
    /// </remarks>
    public sealed class SendOrderSmsEvent : INotificationHandler<OrderDomainEvent>
    {
        /// <summary>
        /// Handles the <see cref="OrderDomainEvent"/> by sending an SMS.
        /// </summary>
        /// <param name="notification">The domain event containing order details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A completed task.</returns>
        public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Implement SMS sending logic here.
            return Task.CompletedTask;
        }
    }
}