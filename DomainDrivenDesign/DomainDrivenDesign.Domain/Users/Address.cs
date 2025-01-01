namespace DomainDrivenDesign.Domain.Users
{
    /// <summary>
    /// Represents a physical address of a user.
    /// </summary>
    /// <remarks>
    /// Implements the Value Object pattern, ensuring immutability and equality based on address properties.
    /// </remarks>
    /// <param name="Country">The country of the address.</param>
    /// <param name="City">The city of the address.</param>
    /// <param name="Street">The street name of the address.</param>
    /// <param name="FullAddress">The complete address including street, city, and country.</param>
    /// <param name="PostalCode">The postal code of the address.</param>
    public sealed record Address(
        string Country,
        string City,
        string Street,
        string FullAddress,
        string PostalCode);
}