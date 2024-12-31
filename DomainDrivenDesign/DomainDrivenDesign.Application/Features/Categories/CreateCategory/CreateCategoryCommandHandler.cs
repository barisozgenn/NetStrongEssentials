using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using MediatR;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Categories.CreateCategory
{
    /// <summary>
    /// Handler responsible for processing <see cref="CreateCategoryCommand"/>.
    /// </summary>
    internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCategoryCommandHandler"/> class.
        /// </summary>
        /// <param name="categoryRepository">Repository for category data access.</param>
        /// <param name="unitOfWork">Unit of work for managing transactions.</param>
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handles the creation of a new category.
        /// </summary>
        /// <param name="request">The <see cref="CreateCategoryCommand"/> containing category details.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Create a new category entity with the provided name.
            await _categoryRepository.CreateAsync(request.Name, cancellationToken);

            // Persist the changes to the database.
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}