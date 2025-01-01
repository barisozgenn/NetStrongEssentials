using DomainDrivenDesign.Application.Features.Categories.CreateCategory;
using DomainDrivenDesign.Application.Features.Categories.GetAllCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.PresentationWebApi.Controllers
{
    /// <summary>
    /// API controller for managing categories.
    /// </summary>
    /// <remarks>
    /// Exposes endpoints to create and retrieve categories.
    /// Utilizes MediatR to handle commands and queries, promoting a clean separation of concerns.
    /// </remarks>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesController"/> class with the specified mediator.
        /// </summary>
        /// <param name="mediator">The mediator used for sending commands and queries.</param>
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new category with the specified name.
        /// </summary>
        /// <param name="request">The command containing category creation details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An HTTP response indicating the outcome of the operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
            return NoContent(); // Returns HTTP 204 No Content to indicate successful creation.
        }

        /// <summary>
        /// Retrieves all categories from the data store.
        /// </summary>
        /// <param name="request">The query containing retrieval details.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An HTTP response containing the list of categories.</returns>
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response); // Returns HTTP 200 OK with the list of categories.
        }
    }
}