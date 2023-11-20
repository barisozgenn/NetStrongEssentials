using MediatR;

namespace DomainDrivenDesign.Domain.Users.Events;

public sealed class SendRegisterEmailEvent : INotificationHandler<UserDomainEvent>
{
    public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
    {
        //Kullanıcı için register email gönderme işlemi
        return Task.CompletedTask;
    }
}
