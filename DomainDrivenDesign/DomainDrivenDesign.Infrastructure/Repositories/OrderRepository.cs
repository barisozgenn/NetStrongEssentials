using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories
{
    /// <summary>
    /// Provides data access functionalities for <see cref="Order"/> entities.
    /// </summary>
    /// <remarks>
    /// Implements the <see cref="IOrderRepository"/> interface to handle CRUD operations for orders.
    /// Utilizes <see cref="ApplicationDbContext"/> for interacting with the database.
    /// </remarks>
    internal sealed class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The database context used for data access operations.</param>
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new order with the specified order details.
        /// </summary>
        /// <param name="createOrderDtos">A list of DTOs containing order line details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The created <see cref="Order"/> entity.</returns>
        public async Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default)
        {
            // Initialize a new Order entity with a unique identifier and default status.
            Order order = new(
                Guid.NewGuid(),
                orderNumber: GenerateOrderNumber(), // Implement a method to generate unique order numbers.
                createdDate: DateTime.UtcNow,
                status: OrderStatusEnum.WaitingForApproval);

            // Populate the Order with order lines based on the provided DTOs.
            order.CreateOrder(createOrderDtos);

            // Add the new order to the context for insertion into the database.
            await _context.Orders.AddAsync(order, cancellationToken);

            return order;
        }

        /// <summary>
        /// Retrieves all orders from the data store, including related order lines and products.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A list of all <see cref="Order"/> entities with their associated order lines and products.</returns>
        public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            // Fetch all orders along with their order lines and associated products.
            return await _context.Orders
                .Include(o => o.OrderLines)
                    .ThenInclude(ol => ol.Product)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Generates a unique order number.
        /// </summary>
        /// <returns>A unique string representing the order number.</returns>
        /// <remarks>
        /// This method should implement a reliable mechanism for generating unique order numbers,
        /// such as using a sequential number, GUID, or integrating with an external service.
        /// </remarks>
        private string GenerateOrderNumber()
        {
            // TODO: Implement a robust order number generation strategy.
            return Guid.NewGuid().ToString().ToUpper().Replace("-", "").Substring(0, 10);
        }
    }
}