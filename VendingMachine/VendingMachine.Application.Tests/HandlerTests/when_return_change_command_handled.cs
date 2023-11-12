using VendingMachine.Application.Commands;
using VendingMachine.Application.Handlers.Commands;
using VendingMachine.Domain.Aggregates;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Values;
using VendingMachine.Infrastructure.Repositories.User;
using VendingMachine.Infrastructure.Repositories.VendingMachine;

namespace VendingMachine.Application.Tests.HandlerTests
{
    public class when_return_change_command_handled
    {
        private readonly IVendingMachineRepository _vendingMachineRepository = Substitute.For<IVendingMachineRepository>();
        private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
        private readonly ReturnChangeCommandHandler _commandHandler;
        private readonly ReturnChangeCommand _command;

        public when_return_change_command_handled()
        {
            var user = User.Create(Money.FromAmount(100), new List<VendingMachineProduct>());

            var product = VendingMachineProduct.Create("Foo", Money.FromAmount(10));
            var productSlot = VendingMachineProductSlot.Create(product, Quantity.FromValue(10));
            var vendingMachine = Domain.Aggregates.VendingMachine.Create(
                productSlots: new List<VendingMachineProductSlot>() { productSlot },
                moneyBox: Money.FromAmount(50));

            _userRepository.Get().Returns(user);
            _vendingMachineRepository.Get().Returns(vendingMachine);

            _commandHandler = new ReturnChangeCommandHandler(
                _userRepository,
                _vendingMachineRepository);

            _command = new ReturnChangeCommand();

            _commandHandler.Handle(_command, CancellationToken.None).Wait();
        }

        [Test]
        public void then_save_user_called_with_correct_changes()
        {
            _userRepository.Received(1).Save(Arg.Is<User>(user => _ValidateUserChanges(user)));
        }

        private bool _ValidateUserChanges(User user)
        {
            user.Money.Amount.ShouldBe(150);
            return true;
        }

        [Test]
        public void then_save_vending_machine_called_with_correct_changes()
        {
            _vendingMachineRepository.Received(1).Save(Arg.Is<Domain.Aggregates.VendingMachine>(vendingMachine => _ValidateVendingMachineChanges(vendingMachine)));
        }

        private bool _ValidateVendingMachineChanges(Domain.Aggregates.VendingMachine vendingMachine)
        {
            vendingMachine.MoneyBox.Amount.ShouldBe(0);
            return true;
        }
    }
}
