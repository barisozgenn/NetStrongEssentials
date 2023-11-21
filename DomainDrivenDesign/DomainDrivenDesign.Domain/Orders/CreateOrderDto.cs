namespace DomainDrivenDesign.Domain.Orders;
//NOTE: sealed class: prevents this class from being inherited into another class.
// DTO stands for Data Transfer Object
//The primary purpose of a DTO is to encapsulate and transfer data in a structured format, often used in situations where different components or layers of a system need to exchange data.
//DTOs are used to reduce the number of method calls and minimize the data transferred over the network, as opposed to sending individual pieces of data.
public sealed record CreateOrderDto(
    Guid ProductId,
    int Quantity,
    decimal Amount,
    string Currency);
