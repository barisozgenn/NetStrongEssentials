using MediatR;

namespace DomainDrivenDesign.Domain.Orders.Events;
//NOTE: sealed class: prevents this class from being inherited into another class.
public sealed class OrderDomainEvent : INotification
{
    public Order Order { get; }
    public OrderDomainEvent(Order order)
    {
        Order = order;
    }
}
