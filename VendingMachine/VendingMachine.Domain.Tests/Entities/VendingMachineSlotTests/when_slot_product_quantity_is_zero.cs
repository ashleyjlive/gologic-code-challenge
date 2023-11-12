using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Exceptions;
using VendingMachine.Domain.Tests.Builders;
using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Entities.VendingMachineSlotTests
{
    public class when_slot_product_quantity_is_zero
    {
        private readonly VendingMachineProductSlot _vendingMachineSlot;

        public when_slot_product_quantity_is_zero()
        {
            _vendingMachineSlot = VendingMachineProductSlot.Create(
                product: FakeProductBuilder.New.Build(),
                stock: new Quantity(0));
        }

        [Test]
        public void then_dispensing_fails_with_insufficient_stock_exception()
        {
            Should.Throw<InsufficientStockException>(() => _vendingMachineSlot.Dispense());
        }
    }
}
