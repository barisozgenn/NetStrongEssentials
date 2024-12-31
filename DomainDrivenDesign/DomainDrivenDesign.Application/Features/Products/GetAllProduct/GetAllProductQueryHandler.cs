using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Products.GetAllProduct
{
    /// <summary>
    /// Handler responsible for processing <see cref="GetAllProductQuery"/>.
    /// </summary>
    internal sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllProductQueryHandler"/> class.
        /// </summary>
        /// <param name="productRepository">Repository for product data access.</param>
        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the retrieval of all products.
        /// </summary>
        /// <param name="request">The <see cref="GetAllProductQuery"/> containing query details.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>A list of <see cref="Product"/> entities.</returns>
        public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all products from the repository.
            return await _productRepository.GetAllAsync(cancellationToken);
        }
    }
}