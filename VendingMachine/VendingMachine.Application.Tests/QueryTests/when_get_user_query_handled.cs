using VendingMachine.Application.Handlers.Queries;
using VendingMachine.Application.Models.User;
using VendingMachine.Application.Queries.User;
using VendingMachine.Domain.Aggregates;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Values;
using VendingMachine.Infrastructure.Repositories.User;

namespace VendingMachine.Application.Tests.QueryTests
{
    public class when_get_user_query_handled
    {
        private readonly User _user;
        private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
        private readonly GetUserQueryHandler _queryHandler;
        private readonly GetUserQuery _query;
        private readonly UserDto _userDto;

        public when_get_user_query_handled()
        {
            _user = User.Create(Money.FromAmount(100), new List<VendingMachineProduct>());
            _userRepository.Get().Returns(_user);

            _queryHandler = new GetUserQueryHandler(
                _userRepository);

            _query = new GetUserQuery();

            _userDto = _queryHandler.Handle(_query, CancellationToken.None).Result;
        }

        [Test]
        public void then_user_id_matches()
        {
            _userDto.Id.ShouldBe(_user.Id);
        }

        [Test]
        public void then_user_money_matches()
        {
            _userDto.Money.ShouldBe(100);
        }
    }
}
