using DomainDrivenDesign.Domain.Users;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Users.GetAllUser
{
    /// <summary>
    /// Handler responsible for processing <see cref="GetAllUserQuery"/>.
    /// </summary>
    internal sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUserQueryHandler"/> class.
        /// </summary>
        /// <param name="userRepository">Repository for user data access.</param>
        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Handles the retrieval of all users.
        /// </summary>
        /// <param name="request">The <see cref="GetAllUserQuery"/> containing query details.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>A list of <see cref="User"/> entities.</returns>
        public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            // Retrieve all users from the repository.
            return await _userRepository.GetAllAsync(cancellationToken);
        }
    }
}