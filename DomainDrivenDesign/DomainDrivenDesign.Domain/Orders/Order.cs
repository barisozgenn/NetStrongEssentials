using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Orders
{
    /// <summary>
    /// Represents an order within the domain.
    /// </summary>
    /// <remarks>
    /// A <see cref="Order"/> aggregates one or more <see cref="OrderLine"/> entities and maintains the overall state and behavior of an order.
    /// Implements various design patterns including Factory Method, Repository, and Value Object patterns.
    /// </remarks>
    public sealed class Order : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the order.</param>
        private Order(Guid id) : base(id)
        {
            // Private constructor to enforce the use of public constructors for object creation.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class with essential properties.
        /// </summary>
        /// <param name="id">The unique identifier for the order.</param>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="createdDate">The date the order was created.</param>
        /// <param name="status">The current status of the order.</param>
        public Order(Guid id, string orderNumber, DateTime createdDate, OrderStatusEnum status) : base(id)
        {
            OrderNumber = orderNumber;
            CreatedDate = createdDate;
            Status = status;
            OrderLines = new List<OrderLine>();
        }

        /// <summary>
        /// Gets the order number.
        /// </summary>
        public string OrderNumber { get; private set; }

        /// <summary>
        /// Gets the date the order was created.
        /// </summary>
        public DateTime CreatedDate { get; private set; }

        /// <summary>
        /// Gets the current status of the order.
        /// </summary>
        public OrderStatusEnum Status { get; private set; }

        /// <summary>
        /// Gets the collection of order lines associated with this order.
        /// </summary>
        public ICollection<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();

        /// <summary>
        /// Creates order lines based on the provided list of <see cref="CreateOrderDto"/> objects.
        /// </summary>
        /// <param name="createOrderDtos">A list of DTOs containing order line details.</param>
        /// <exception cref="ArgumentException">Thrown when an order line has a quantity less than 1.</exception>
        public void CreateOrder(List<CreateOrderDto> createOrderDtos)
        {
            foreach (var item in createOrderDtos)
            {
                if (item.Quantity < 1)
                {
                    throw new ArgumentException("Order quantity cannot be less than 1!");
                }

                // TODO: Add additional business rules as necessary.

                // Create a new OrderLine based on the provided data.
                OrderLine orderLine = new(
                    Guid.NewGuid(),
                    Id,
                    item.ProductId,
                    item.Quantity,
                    new Money(item.Amount, Currency.FromCode(item.Currency)));

                // Add the created OrderLine to the collection of OrderLines.
                OrderLines.Add(orderLine);
            }
        }

        /// <summary>
        /// Removes an order line from the order based on its unique identifier.
        /// </summary>
        /// <param name="orderLineId">The unique identifier of the order line to remove.</param>
        /// <exception cref="ArgumentException">Thrown when the specified order line is not found.</exception>
        public void RemoveOrderLine(Guid orderLineId)
        {
            var orderLine = OrderLines.FirstOrDefault(p => p.Id == orderLineId);
            if (orderLine is null)
            {
                throw new ArgumentException("The order line you want to delete could not be found!");
            }

            // Remove the specified OrderLine from the collection.
            OrderLines.Remove(orderLine);
        }
    }
}