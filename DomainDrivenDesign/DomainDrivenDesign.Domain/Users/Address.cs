namespace DomainDrivenDesign.Domain.Users;
//NOTE: Records in C# are immutable by default. Once the values are set during construction, they cannot be changed.
//This aligns well with the concept of value objects, like Address, which typically shouldn't be mutable.
public sealed record Address(
    string Country,
    string City,
    string Street,
    string FullAddress,
    string PostalCode);
