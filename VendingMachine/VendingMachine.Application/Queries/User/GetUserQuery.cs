using MediatR;
using VendingMachine.Application.Models.User;

namespace VendingMachine.Application.Queries.User
{
    public class GetUserQuery : IRequest<UserDto>
    {
    }
}
