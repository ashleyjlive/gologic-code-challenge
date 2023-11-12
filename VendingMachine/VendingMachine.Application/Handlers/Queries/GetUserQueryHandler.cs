using MediatR;
using VendingMachine.Application.Converters;
using VendingMachine.Application.Models.User;
using VendingMachine.Application.Queries.User;
using VendingMachine.Infrastructure.Repositories.User;

namespace VendingMachine.Application.Handlers.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Get();
            var userDto = user.ToDTO();
            return Task.FromResult(userDto);
        }
    }
}
