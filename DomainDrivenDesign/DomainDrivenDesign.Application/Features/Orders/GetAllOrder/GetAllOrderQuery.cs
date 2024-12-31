using DomainDrivenDesign.Domain.Orders;
using MediatR;
using System.Collections.Generic;

namespace DomainDrivenDesign.Application.Features.Orders.GetAllOrder
{
    /// <summary>
    /// Query to retrieve all orders.
    /// </summary>
    public sealed record GetAllOrderQuery() : IRequest<List<Order>>;
}