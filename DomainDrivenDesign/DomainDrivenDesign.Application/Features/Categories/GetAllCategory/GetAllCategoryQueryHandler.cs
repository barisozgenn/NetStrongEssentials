using DomainDrivenDesign.Domain.Categories;
using MediatR;
namespace DomainDrivenDesign.Application.Features.Categories.GetAllCategory
{
    /// <summary>
    /// Handler responsible for processing <see cref="GetAllCategoryQuery"/>.
    /// </summary>
    internal sealed class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllCategoryQueryHandler"/> class.
        /// </summary>
        /// <param name="categoryRepository">Repository for category data access.</param>
        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Handles the retrieval of all categories.
        /// </summary>
        /// <param name="request">The <see cref="GetAllCategoryQuery"/> containing query details.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>A list of <see cref="Category"/> entities.</returns>
        public async Task<List<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all categories from the repository.
            return await _categoryRepository.GetAllAsync(cancellationToken);
        }
    }
}