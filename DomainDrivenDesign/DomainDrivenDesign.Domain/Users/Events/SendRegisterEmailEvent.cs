using MediatR;

namespace DomainDrivenDesign.Domain.Users.Events;
//NOTE: Here is DDD/Technical Design/Domain Events with mediatR nuget.
public sealed class SendRegisterEmailEvent : INotificationHandler<UserDomainEvent>
{
    public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
    {
        //Send an email to user to register
        return Task.CompletedTask;
    }
}
