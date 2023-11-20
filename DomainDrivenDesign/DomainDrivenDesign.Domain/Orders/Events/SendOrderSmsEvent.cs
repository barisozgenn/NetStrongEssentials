using MediatR;

namespace DomainDrivenDesign.Domain.Orders.Events;

//NOTE: sealed class: prevents this class from being inherited into another class.
public sealed class SendOrderSmsEvent : INotificationHandler<OrderDomainEvent>
{
    public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
    {
        //Sms gönderme işlemi
        return Task.CompletedTask;
    }
}



