namespace DomainDrivenDesign.Domain.Categories
{
    /// <summary>
    /// Defines the contract for category data access operations.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Creates a new category with the specified name.
        /// </summary>
        /// <param name="name">The name of the category to create.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CreateAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all categories from the data store.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A list of all <see cref="Category"/> entities.</returns>
        Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}