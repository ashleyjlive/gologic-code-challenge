using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Tests.Builders;
using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Entities.VendingMachineSlotTests
{
    public class when_slot_product_quantity_is_five
    {
        private readonly VendingMachineProductSlot _vendingMachineSlot;

        public when_slot_product_quantity_is_five()
        {
            _vendingMachineSlot = VendingMachineProductSlot.Create(
                product: FakeProductBuilder.New.Build(),
                stock: new Quantity(5));
        }

        [Test]
        public void then_stock_is_decremented_when_dispensed()
        {
            _vendingMachineSlot.Dispense();
            _vendingMachineSlot.Stock.Value.ShouldBe((uint)4);
        }
    }
}
