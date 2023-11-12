using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Exceptions;
using VendingMachine.Domain.Tests.Builders;
using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Aggregates.VendingMachineTests
{
    public class when_insufficient_stock_remain
    {
        private readonly VendingMachineProductSlot _slot;
        private readonly Domain.Aggregates.VendingMachine _vendingMachine;

        public when_insufficient_stock_remain()
        {
            var product = FakeProductBuilder.New
                .WithPrice(new Money(50.0m))
                .Build();
            _slot = VendingMachineProductSlot.Create(product, new Quantity(0));

            _vendingMachine = Domain.Aggregates.VendingMachine.Create(
                productSlots: new VendingMachineProductSlot[] { _slot },
                moneyBox: Money.None);

            _vendingMachine.InsertMoney(new Money(25m));
        }

        public void then_purchasing_fails_with_insufficient_stock_exception()
        {
            Should.Throw<InsufficientStockException>(() => _vendingMachine.PurchaseProduct(_slot.Id));
        }
    }
}
