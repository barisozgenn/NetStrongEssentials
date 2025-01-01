using MediatR;

namespace DomainDrivenDesign.Domain.Orders.Events
{
    /// <summary>
    /// Represents a domain event that occurs when an order is created.
    /// </summary>
    /// <remarks>
    /// Implements <see cref="INotification"/> to enable publishing through MediatR.
    /// </remarks>
    public sealed class OrderDomainEvent : INotification
    {
        /// <summary>
        /// Gets the order associated with this event.
        /// </summary>
        public Order Order { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDomainEvent"/> class with the specified order.
        /// </summary>
        /// <param name="order">The order that was created.</param>
        public OrderDomainEvent(Order order)
        {
            Order = order;
        }
    }
}