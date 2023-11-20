namespace DomainDrivenDesign.Domain.Orders;
//NOTE: sealed class: prevents this class from being inherited into another class.

public sealed record CreateOrderDto(
    Guid ProductId, 
    int Quantity, 
    decimal Amount, 
    string Currency);
