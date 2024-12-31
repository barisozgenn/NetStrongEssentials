using DomainDrivenDesign.Domain.Users;
using MediatR;
using System.Collections.Generic;

namespace DomainDrivenDesign.Application.Features.Users.GetAllUser
{
    /// <summary>
    /// Query to retrieve all users.
    /// </summary>
    public sealed record GetAllUserQuery() : IRequest<List<User>>;
}