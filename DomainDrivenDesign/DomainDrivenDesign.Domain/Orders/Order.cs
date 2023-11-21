using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainDrivenDesign.Domain.Orders
{
    // NOTE: Sealed class prevents this class from being inherited into another class.
// Design Patterns:
// Factory Method Pattern: The private constructor is used as a factory method for creating instances of the Order class.
// Repository Pattern: The collection of OrderLines represents an association and can be considered a form of repository for OrderLine entities associated with an Order. This allows easy manipulation of associated order lines.
// Value Object Pattern: The Money class is a value object representing the amount and currency, ensuring immutability and equality based on content.
    public sealed class Order : Entity
    {
        private Order(Guid id) : base(id)
        {
            // Private constructor to be used internally for creating instances.
        }
        // Constructor for creating a new Order with essential properties.
        public Order(Guid id, string orderNumber, DateTime createdDate, OrderStatusEnum status) : base(id)
        {
            OrderNumber = orderNumber;
            CreatedDate = createdDate;
            Status = status;
        }
        // Properties of the Order class.
        public string OrderNumber { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public OrderStatusEnum Status { get; private set; }
        // ICollection to represent a collection of OrderLine entities associated with this Order.
        //ICollection<OrderLine> interface. List<T> is a dynamic array that provides methods for adding, removing, and manipulating elements in a list.
        public ICollection<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();
        // Method to create an order based on a list of CreateOrderDto objects.
        public void CreateOrder(List<CreateOrderDto> createOrderDtos)
        {
            foreach (var item in createOrderDtos)
            {
                if (item.Quantity < 1)
                {
                    // Throw an exception if the quantity is less than 1.
                    throw new ArgumentException("Order quantity cannot be less than 1!");
                }

                // Additional business rules can be added here.

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
        // Method to remove an OrderLine from the collection based on its id.
        public void RemoveOrderLine(Guid orderLineId)
        {
            var orderLine = OrderLines.FirstOrDefault(p => p.Id == orderLineId);
            if (orderLine is null)
            {
                // Throw an exception if the OrderLine to be removed is not found.
                throw new ArgumentException("The order line you want to delete could not be found!");
            }
            // Remove the specified OrderLine from the collection.
            OrderLines.Remove(orderLine);
        }
    }
}
