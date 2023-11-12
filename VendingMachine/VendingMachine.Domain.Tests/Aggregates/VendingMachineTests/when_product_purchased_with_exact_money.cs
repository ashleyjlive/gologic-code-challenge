using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Tests.Builders;
using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Aggregates.VendingMachineTests
{
    public class when_product_purchased_with_exact_money
    {
        private readonly VendingMachineProductSlot _slot;
        private readonly Domain.Aggregates.VendingMachine _vendingMachine;

        public when_product_purchased_with_exact_money()
        {
            var product = FakeProductBuilder.New
                .WithPrice(new Money(50.0m))
                .Build();
            _slot = VendingMachineProductSlot.Create(product, new Quantity(5));

            _vendingMachine = Domain.Aggregates.VendingMachine.Create(
                productSlots: new VendingMachineProductSlot[] { _slot },
                moneyBox: Money.None);

            _vendingMachine.InsertMoney(new Money(50.0m));
            _vendingMachine.PurchaseProduct(_slot.Id);
        }

        [Test]
        public void then_stock_quantity_decremented()
        {
            var slot = _vendingMachine.GetSlot(_slot.Id).ShouldNotBeNull();
            slot.Stock.Value.ShouldBe((uint)4);
        }

        [Test]
        public void then_money_box_is_now_empty()
        {
            _vendingMachine.MoneyBox.Amount.ShouldBe(0);
        }
    }
}
