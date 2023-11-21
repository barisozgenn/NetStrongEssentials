namespace DomainDrivenDesign.Domain.Products;
public interface IProductRepository
{
    //NOTE: Using cancellation tokens is especially useful in scenarios where long-running asynchronous operations need to be responsive to external events or user interactions. 
    //It allows for a graceful way to stop or interrupt an operation without leaving resources hanging or causing unnecessary delays.
    Task CreateAsync(string name, int quantity, decimal amount, string currency, Guid categoryId, CancellationToken cancellationToken = default);
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default);
}
