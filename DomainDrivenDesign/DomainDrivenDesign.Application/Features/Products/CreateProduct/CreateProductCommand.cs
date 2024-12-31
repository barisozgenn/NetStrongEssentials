using MediatR;
using System;

namespace DomainDrivenDesign.Application.Features.Products.CreateProduct
{
    /// <summary>
    /// Command to create a new product with the specified details.
    /// </summary>
    /// <param name="Name">The name of the product.</param>
    /// <param name="Quantity">The quantity available.</param>
    /// <param name="Amount">The price of the product.</param>
    /// <param name="Currency">The currency of the price.</param>
    /// <param name="CategoryId">The identifier of the category the product belongs to.</param>
    public sealed record CreateProductCommand(
        string Name,
        int Quantity,
        decimal Amount,
        string Currency,
        Guid CategoryId) : IRequest;
}