using DomainDrivenDesign.Domain.Orders;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Orders.GetAllOrder
{
    /// <summary>
    /// Handler responsible for processing <see cref="GetAllOrderQuery"/>.
    /// </summary>
    internal sealed class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllOrderQueryHandler"/> class.
        /// </summary>
        /// <param name="orderRepository">Repository for order data access.</param>
        public GetAllOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Handles the retrieval of all orders.
        /// </summary>
        /// <param name="request">The <see cref="GetAllOrderQuery"/> containing query details.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>A list of <see cref="Order"/> entities.</returns>
        public async Task<List<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all orders from the repository.
            return await _orderRepository.GetAllAsync(cancellationToken);
        }
    }
}