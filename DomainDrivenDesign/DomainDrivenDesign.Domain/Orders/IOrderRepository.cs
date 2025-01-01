namespace DomainDrivenDesign.Domain.Orders
{
    /// <summary>
    /// Defines the contract for order data access operations.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Creates a new order with the specified order details.
        /// </summary>
        /// <param name="createOrderDtos">A list of DTOs containing order line details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The created <see cref="Order"/> entity.</returns>
        Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all orders from the data store.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A list of all <see cref="Order"/> entities.</returns>
        Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}