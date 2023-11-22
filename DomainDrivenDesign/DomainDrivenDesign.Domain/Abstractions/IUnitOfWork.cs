namespace DomainDrivenDesign.Domain.Abstractions;
//NOTE: In DDD, the Unit of Work pattern ensures that a set of operations is treated as a single, atomic transaction, allowing for consistent state changes or rollbacks across multiple repositories.
//NOTE: A Unit of Work is a design pattern that groups a set of related operations, typically database transactions, to maintain consistency and ensure that either all operations succeed or none do.
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
