using MediatR;

namespace DomainDrivenDesign.Application.Features.Users.CreateUser
{
    /// <summary>
    /// Command to create a new user with the specified details.
    /// </summary>
    /// <param name="Name">The name of the user.</param>
    /// <param name="Email">The email address of the user.</param>
    /// <param name="Password">The password for the user account.</param>
    /// <param name="Country">The country of the user.</param>
    /// <param name="City">The city of the user.</param>
    /// <param name="Street">The street address of the user.</param>
    /// <param name="PostalCode">The postal code of the user's address.</param>
    /// <param name="FullAddress">The complete address of the user.</param>
    public sealed record CreateUserCommand(
        string Name,
        string Email,
        string Password,
        string Country,
        string City,
        string Street,
        string PostalCode,
        string FullAddress) : IRequest;
}