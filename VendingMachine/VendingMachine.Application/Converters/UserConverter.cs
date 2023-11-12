using VendingMachine.Application.Models.User;
using VendingMachine.Domain.Aggregates;

namespace VendingMachine.Application.Converters
{
    public static class UserConverter
    {
        public static UserDto ToDTO(this User user)
        {
            return new UserDto(user.Id, user.Money.Amount);
        }
    }
}
