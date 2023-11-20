using MediatR;

namespace DomainDrivenDesign.Domain.Orders.Events;
//NOTE: sealed class: prevents this class from being inherited into another class.
public sealed class SendOrderEmailEvent : INotificationHandler<OrderDomainEvent>
{
    public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
    {
        //Mail gönderme işlemi
        return Task.CompletedTask;
    }
}



