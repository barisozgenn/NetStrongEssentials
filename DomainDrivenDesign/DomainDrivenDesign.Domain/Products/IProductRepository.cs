namespace DomainDrivenDesign.Domain.Products
{
    /// <summary>
    /// Defines the contract for product data access operations.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Creates a new product with the specified details.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="quantity">The quantity of the product available.</param>
        /// <param name="amount">The price per unit of the product.</param>
        /// <param name="currency">The currency in which the amount is denominated.</param>
        /// <param name="categoryId">The unique identifier of the category the product belongs to.</param>
        /// <param name="cancellationToken">
        /// A token to monitor for cancellation requests.
        /// Using cancellation tokens is especially useful in scenarios where long-running asynchronous operations need to be responsive to external events or user interactions.
        /// It allows for a graceful way to stop or interrupt an operation without leaving resources hanging or causing unnecessary delays.
        /// </param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CreateAsync(string name, int quantity, decimal amount, string currency, Guid categoryId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all products from the data store.
        /// </summary>
        /// <param name="cancellationToken">
        /// A token to monitor for cancellation requests.
        /// Using cancellation tokens is especially useful in scenarios where long-running asynchronous operations need to be responsive to external events or user interactions.
        /// It allows for a graceful way to stop or interrupt an operation without leaving resources hanging or causing unnecessary delays.
        /// </param>
        /// <returns>A list of all <see cref="Product"/> entities.</returns>
        Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}