using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Exceptions;
using VendingMachine.Domain.Tests.Builders;
using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Aggregates.VendingMachineTests
{
    public class when_insufficient_funds_entered
    {
        private readonly VendingMachineProductSlot _slot;
        private readonly Domain.Aggregates.VendingMachine _vendingMachine;

        public when_insufficient_funds_entered()
        {
            var product = FakeProductBuilder.New
                .WithPrice(new Money(50.0m))
                .Build();
            _slot = VendingMachineProductSlot.Create(product, new Quantity(5));

            _vendingMachine = Domain.Aggregates.VendingMachine.Create(
                productSlots: new VendingMachineProductSlot[] { _slot },
                moneyBox: Money.None);

            _vendingMachine.InsertMoney(new Money(25m));
        }

        public void then_purchasing_fails_with_insufficient_money_exception()
        {
            Should.Throw<InsufficientMoneyException>(() => _vendingMachine.PurchaseProduct(_slot.Id));
        }
    }
}
