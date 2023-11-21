using MediatR;

namespace DomainDrivenDesign.Domain.Orders.Events;

//NOTE: sealed class: prevents this class from being inherited into another class.
//NOTE: Here is DDD/Technical Design/Domain Events with mediatR nuget.
public sealed class SendOrderSmsEvent : INotificationHandler<OrderDomainEvent>
{
    public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
    {
        //Send SMS 
        return Task.CompletedTask;
    }
}



