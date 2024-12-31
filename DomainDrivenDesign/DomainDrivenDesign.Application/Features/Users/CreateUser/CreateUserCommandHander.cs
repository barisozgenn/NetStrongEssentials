using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Domain.Users.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Users.CreateUser
{
    /// <summary>
    /// Handler responsible for processing <see cref="CreateUserCommand"/>.
    /// </summary>
    internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserCommandHandler"/> class.
        /// </summary>
        /// <param name="userRepository">Repository for user data access.</param>
        /// <param name="unitOfWork">Unit of work for managing transactions.</param>
        /// <param name="mediator">Mediator for publishing domain events.</param>
        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        /// <summary>
        /// Handles the creation of a new user.
        /// </summary>
        /// <param name="request">The <see cref="CreateUserCommand"/> containing user details.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Define and apply business rules here if necessary.

            // Create a new user using the repository.
            var user = await _userRepository.CreateAsync(
                request.Name,
                request.Email,
                request.Password,
                request.Country,
                request.City,
                request.Street,
                request.PostalCode,
                request.FullAddress,
                cancellationToken);

            // Persist the changes to the database.
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // Publish a domain event indicating a new user has been created.
            await _mediator.Publish(new UserDomainEvent(user), cancellationToken);
        }
    }
}