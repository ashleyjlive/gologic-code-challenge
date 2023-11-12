using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Exceptions;
using VendingMachine.Domain.Tests.Builders;
using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Aggregates.VendingMachineTests
{
    public class when_slot_is_missing
    {
        private readonly Guid _slotId = Guid.NewGuid();

        private readonly VendingMachineProductSlot _slot;
        private readonly Domain.Aggregates.VendingMachine _vendingMachine;

        public when_slot_is_missing()
        {
            var product = FakeProductBuilder.New
                .WithPrice(new Money(50.0m))
                .Build();
            _slot = VendingMachineProductSlot.Create(product, new Quantity(5));

            _vendingMachine = Domain.Aggregates.VendingMachine.Create(
                moneyBox: Money.None,
                productSlots: new VendingMachineProductSlot[] { _slot });
        }

        public void then_purchase_product_fails_with_slot_missing_error()
        {
            Should.Throw<ProductSlotNotFoundException>(() => _vendingMachine.PurchaseProduct(_slotId));
        }
    }
}
