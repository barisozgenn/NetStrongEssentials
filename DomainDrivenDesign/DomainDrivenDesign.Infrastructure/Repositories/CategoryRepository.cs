using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories
{
    /// <summary>
    /// Provides data access functionalities for <see cref="Category"/> entities.
    /// </summary>
    /// <remarks>
    /// Implements the <see cref="ICategoryRepository"/> interface to handle CRUD operations for categories.
    /// Utilizes <see cref="ApplicationDbContext"/> for interacting with the database.
    /// </remarks>
    internal sealed class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The database context used for data access operations.</param>
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new category with the specified name.
        /// </summary>
        /// <param name="name">The name of the category to create.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
        {
            // Create a new Category entity with a unique identifier and validated name.
            Category category = new(Guid.NewGuid(), new Name(name));

            // Add the new category to the context for insertion into the database.
            await _context.Categories.AddAsync(category, cancellationToken);
        }

        /// <summary>
        /// Retrieves all categories from the data store.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A list of all <see cref="Category"/> entities.</returns>
        public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            // Fetch all categories from the database asynchronously.
            return await _context.Categories.ToListAsync(cancellationToken);
        }
    }
}