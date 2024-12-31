using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Products.CreateProduct
{
    /// <summary>
    /// Handler responsible for processing <see cref="CreateProductCommand"/>.
    /// </summary>
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductCommandHandler"/> class.
        /// </summary>
        /// <param name="productRepository">Repository for product data access.</param>
        /// <param name="unitOfWork">Unit of work for managing transactions.</param>
        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handles the creation of a new product.
        /// </summary>
        /// <param name="request">The <see cref="CreateProductCommand"/> containing product details.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Create a new product using the repository.
            await _productRepository.CreateAsync(
                request.Name,
                request.Quantity,
                request.Amount,
                request.Currency,
                request.CategoryId,
                cancellationToken);

            // Persist the changes to the database.
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}