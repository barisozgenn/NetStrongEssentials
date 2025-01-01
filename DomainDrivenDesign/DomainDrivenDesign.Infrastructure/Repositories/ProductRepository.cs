using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories
{
    /// <summary>
    /// Provides data access functionalities for <see cref="Product"/> entities.
    /// </summary>
    /// <remarks>
    /// Implements the <see cref="IProductRepository"/> interface to handle CRUD operations for products.
    /// Utilizes <see cref="ApplicationDbContext"/> for interacting with the database.
    /// </remarks>
    internal sealed class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The database context used for data access operations.</param>
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new product with the specified details.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="quantity">The quantity of the product available.</param>
        /// <param name="amount">The price per unit of the product.</param>
        /// <param name="currency">The currency in which the amount is denominated.</param>
        /// <param name="categoryId">The unique identifier of the category the product belongs to.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the provided currency code is invalid.
        /// </exception>
        public async Task CreateAsync(string name, int quantity, decimal amount, string currency, Guid categoryId, CancellationToken cancellationToken = default)
        {
            // Create a new Product entity with a unique identifier and validated properties.
            Product product = new(
                Guid.NewGuid(),
                new Name(name),
                quantity,
                new Money(amount, Currency.FromCode(currency)),
                categoryId);

            // Add the new product to the context for insertion into the database.
            await _context.Products.AddAsync(product, cancellationToken);
        }

        /// <summary>
        /// Retrieves all products from the data store.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A list of all <see cref="Product"/> entities.</returns>
        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            // Fetch all products from the database asynchronously.
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}