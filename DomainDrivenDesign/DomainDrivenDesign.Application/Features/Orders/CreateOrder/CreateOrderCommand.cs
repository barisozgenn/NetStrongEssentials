using DomainDrivenDesign.Domain.Orders;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Orders.CreateOrder;
//NOTE: We defined here parameter which are required in Domain layer model

public sealed record CreateOrderCommand(
    List<CreateOrderDto> CreateOrderDtos) :IRequest;
