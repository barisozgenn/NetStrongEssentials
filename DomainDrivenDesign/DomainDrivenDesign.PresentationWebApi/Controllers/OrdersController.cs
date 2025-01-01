using DomainDrivenDesign.Application.Features.Orders.CreateOrder;
using DomainDrivenDesign.Application.Features.Orders.GetAllOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.PresentationWebApi.Controllers
{
    /// <summary>
    /// API controller for managing orders.
    /// </summary>
    /// <remarks>
    /// Exposes endpoints to create and retrieve orders.
    /// Utilizes MediatR to handle commands and queries, promoting a clean separation of concerns.
    /// </remarks>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersController"/> class with the specified mediator.
        /// </summary>
        /// <param name="mediator">The mediator used for sending commands and queries.</param>
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new order with the specified order details.
        /// </summary>
        /// <param name="request">The command containing order creation details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An HTTP response indicating the outcome of the operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent(); // Returns HTTP 204 No Content to indicate successful creation.
        }

        /// <summary>
        /// Retrieves all orders from the data store, including their associated order lines and products.
        /// </summary>
        /// <param name="request">The query containing retrieval details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An HTTP response containing the list of orders.</returns>
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response); // Returns HTTP 200 OK with the list of orders.
        }
    }
}