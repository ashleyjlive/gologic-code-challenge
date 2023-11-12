using MediatR;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Infrastructure.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private Domain.Aggregates.User _user;

        public UserRepository()
        {
            _user = Domain.Aggregates.User.Create(Domain.Values.Money.FromAmount(50), Enumerable.Empty<VendingMachineProduct>());
        }

        public Domain.Aggregates.User Get()
        {
            return _user;
        }

        public void Save(Domain.Aggregates.User user)
        {
            _user = user;
        }
    }
}