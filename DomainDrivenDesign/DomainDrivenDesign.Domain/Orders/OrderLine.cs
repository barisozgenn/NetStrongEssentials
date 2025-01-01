using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Orders
{
    /// <summary>
    /// Represents a single line item within an order.
    /// </summary>
    /// <remarks>
    /// An <see cref="OrderLine"/> associates a specific product with an order, including quantity and pricing details.
    /// Implements the <see cref="Entity"/> base class to inherit the unique identifier.
    /// </remarks>
    public sealed class OrderLine : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLine"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the order line.</param>
        private OrderLine(Guid id) : base(id)
        {
            // Private constructor to enforce the use of public constructors for object creation.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLine"/> class with the specified details.
        /// </summary>
        /// <param name="id">The unique identifier for the order line.</param>
        /// <param name="orderId">The unique identifier of the associated order.</param>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <param name="quantity">The quantity of the product ordered.</param>
        /// <param name="price">The price details of the product.</param>
        public OrderLine(Guid id, Guid orderId, Guid productId, int quantity, Money price) : base(id)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        /// <summary>
        /// Gets the unique identifier of the associated order.
        /// </summary>
        public Guid OrderId { get; private set; }

        /// <summary>
        /// Gets the unique identifier of the product.
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// Gets the product associated with this order line.
        /// </summary>
        public Product Product { get; private set; }

        /// <summary>
        /// Gets the quantity of the product ordered.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Gets the pricing details of the product.
        /// </summary>
        public Money Price { get; private set; }
    }
}