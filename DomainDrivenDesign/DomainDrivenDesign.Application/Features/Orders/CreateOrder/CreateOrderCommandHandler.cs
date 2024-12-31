using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Orders.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Orders.CreateOrder
{
    /// <summary>
    /// Handler responsible for processing <see cref="CreateOrderCommand"/>.
    /// </summary>
    internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrderCommandHandler"/> class.
        /// </summary>
        /// <param name="orderRepository">Repository for order data access.</param>
        /// <param name="unitOfWork">Unit of work for managing transactions.</param>
        /// <param name="mediator">Mediator for publishing domain events.</param>
        public CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        /// <summary>
        /// Handles the creation of a new order.
        /// </summary>
        /// <param name="request">The <see cref="CreateOrderCommand"/> containing order details.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Create a new order using the repository.
            var order = await _orderRepository.CreateAsync(request.CreateOrderDtos, cancellationToken);

            // Persist the changes to the database.
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // Publish a domain event indicating a new order has been created.
            await _mediator.Publish(new OrderDomainEvent(order), cancellationToken);
        }
    }
}