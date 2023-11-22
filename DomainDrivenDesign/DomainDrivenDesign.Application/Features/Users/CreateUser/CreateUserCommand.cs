using MediatR;

namespace DomainDrivenDesign.Application.Features.Users.CreateUser;
//NOTE: We defined here parameter which are required in Domain layer model
public sealed record CreateUserCommand(
    string Name, 
    string Email, 
    string Password, 
    string Country, 
    string City, 
    string Street, 
    string PostalCode, 
    string FullAddress) : IRequest;
