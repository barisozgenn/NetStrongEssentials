using DomainDrivenDesign.Domain.Products;
using MediatR;
using System.Collections.Generic;

namespace DomainDrivenDesign.Application.Features.Products.GetAllProduct
{
    /// <summary>
    /// Query to retrieve all products.
    /// </summary>
    public sealed record GetAllProductQuery() : IRequest<List<Product>>;
}