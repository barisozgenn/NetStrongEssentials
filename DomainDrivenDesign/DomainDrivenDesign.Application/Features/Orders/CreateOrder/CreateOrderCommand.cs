using DomainDrivenDesign.Domain.Orders;
using MediatR;
using System.Collections.Generic;

namespace DomainDrivenDesign.Application.Features.Orders.CreateOrder
{
    /// <summary>
    /// Command to create a new order with the specified order details.
    /// </summary>
    /// <param name="CreateOrderDtos">List of order detail data transfer objects.</param>
    public sealed record CreateOrderCommand(List<CreateOrderDto> CreateOrderDtos) : IRequest;
}