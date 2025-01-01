using System;

namespace DomainDrivenDesign.Domain.Orders
{
    /// <summary>
    /// Data Transfer Object (DTO) for creating a new order line.
    /// </summary>
    /// <remarks>
    /// Encapsulates the necessary data required to create an order line, facilitating efficient data transfer between layers.
    /// </remarks>
    /// <param name="ProductId">The unique identifier of the product being ordered.</param>
    /// <param name="Quantity">The quantity of the product to order.</param>
    /// <param name="Amount">The price per unit of the product.</param>
    /// <param name="Currency">The currency in which the amount is denominated.</param>
    public sealed record CreateOrderDto(
        Guid ProductId,
        int Quantity,
        decimal Amount,
        string Currency);
}