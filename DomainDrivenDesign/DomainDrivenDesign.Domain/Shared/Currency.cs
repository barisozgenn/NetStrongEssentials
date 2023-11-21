using System.Diagnostics.Tracing;

namespace DomainDrivenDesign.Domain.Shared;
//NOTE: sealed class: prevents this class from being inherited into another class.
public sealed record Currency
{
    // Define a public static readonly instance representing the absence of currency.
    // it can not be reachable out of this layer
    internal static readonly Currency None = new("");
    // Define public static readonly instances for common currencies.
    public static readonly Currency USD = new("USD");
    public static readonly Currency TRY = new("TRY");
    // Define a property to hold the currency code.
    public string Code { get; init; }
    // Private constructor ensures that instances can only be created within the class.
    // This promotes encapsulation, restricting external code from creating instances directly.
    private Currency(string code)
    {
        Code = code;
    }
    // Factory method to create a Currency instance based on the provided code.
    // This provides a controlled way to create instances, enforcing business rules if needed.
    public static Currency FromCode(string code)
    {
        // Try to find a matching currency instance, otherwise throw an exception.
        return All.FirstOrDefault(p => p.Code == code) ??
            throw new ArgumentException("Invalid currency code!");
    }
    // Define a public static readonly collection containing all valid currency instances.
    // IReadOnlyCollection ensures that external code cannot modify the collection.
    public static readonly IReadOnlyCollection<Currency> All = new[] { USD, TRY };
}

