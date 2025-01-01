namespace DomainDrivenDesign.Domain.Abstractions
{
    /// <summary>
    /// Represents the Unit of Work pattern, coordinating the work of multiple repositories by ensuring that changes are committed as a single transaction.
    /// </summary>
    /// <remarks>
    /// The Unit of Work pattern maintains a list of objects affected by a business transaction and coordinates the writing out of changes and the resolution of concurrency problems.
    /// It ensures that either all operations within the transaction are completed successfully or none are applied, maintaining data consistency.
    /// </remarks>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits all changes made in the context to the underlying data store.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains the number of state entries written to the underlying data store.
        /// </returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}