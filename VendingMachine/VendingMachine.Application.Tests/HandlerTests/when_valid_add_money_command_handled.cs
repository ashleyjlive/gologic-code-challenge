using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Application.Commands;
using VendingMachine.Application.Handlers.Commands;
using VendingMachine.Domain.Aggregates;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Values;
using VendingMachine.Infrastructure.Repositories.User;
using VendingMachine.Infrastructure.Repositories.VendingMachine;

namespace VendingMachine.Application.Tests.HandlerTests
{
    public class when_valid_add_money_command_handled
    {
        private readonly IVendingMachineRepository _vendingMachineRepository = Substitute.For<IVendingMachineRepository>();
        private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
        private readonly AddMoneyCommandHandler _commandHandler;
        private readonly AddMoneyCommand _command;

        public when_valid_add_money_command_handled()
        {
            var user = User.Create(Money.FromAmount(100), new List<VendingMachineProduct>());

            var product = VendingMachineProduct.Create("Foo", Money.FromAmount(10));
            var productSlot = VendingMachineProductSlot.Create(product, Quantity.FromValue(10));
            var vendingMachine = Domain.Aggregates.VendingMachine.Create(
                productSlots: new List<VendingMachineProductSlot>() { productSlot },
                moneyBox: Money.None);

            _userRepository.Get().Returns(user);
            _vendingMachineRepository.Get().Returns(vendingMachine);

            _commandHandler = new AddMoneyCommandHandler(
                _userRepository,
                _vendingMachineRepository);

            _command = new AddMoneyCommand(amount: 30);

            _commandHandler.Handle(_command, CancellationToken.None).Wait();
        }

        [Test]
        public void then_save_user_called_with_correct_changes()
        {
            _userRepository.Received(1).Save(Arg.Is<User>(user => _ValidateUserChanges(user)));
        }

        private bool _ValidateUserChanges(User user)
        {
            user.Money.Amount.ShouldBe(70);
            return true;
        }

        [Test]
        public void then_save_vending_machine_called_with_correct_changes()
        {
            _vendingMachineRepository.Received(1).Save(Arg.Is<Domain.Aggregates.VendingMachine>(vendingMachine => _ValidateVendingMachineChanges(vendingMachine)));
        }

        private bool _ValidateVendingMachineChanges(Domain.Aggregates.VendingMachine vendingMachine)
        {
            vendingMachine.MoneyBox.Amount.ShouldBe(30);
            return true;
        }
    }
}
