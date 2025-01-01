using DomainDrivenDesign.Application.Features.Products.CreateProduct;
using DomainDrivenDesign.Application.Features.Products.GetAllProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.PresentationWebApi.Controllers
{
    /// <summary>
    /// API controller for managing products.
    /// </summary>
    /// <remarks>
    /// Exposes endpoints to create and retrieve products.
    /// Utilizes MediatR to handle commands and queries, promoting a clean separation of concerns.
    /// </remarks>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class with the specified mediator.
        /// </summary>
        /// <param name="mediator">The mediator used for sending commands and queries.</param>
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new product with the specified details.
        /// </summary>
        /// <param name="request">The command containing product creation details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An HTTP response indicating the outcome of the operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent(); // Returns HTTP 204 No Content to indicate successful creation.
        }

        /// <summary>
        /// Retrieves all products from the data store.
        /// </summary>
        /// <param name="request">The query containing retrieval details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An HTTP response containing the list of products.</returns>
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response); // Returns HTTP 200 OK with the list of products.
        }
    }
}