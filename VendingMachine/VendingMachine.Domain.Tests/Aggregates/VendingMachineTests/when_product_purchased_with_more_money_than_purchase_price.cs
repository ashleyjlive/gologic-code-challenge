using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Tests.Builders;
using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Aggregates.VendingMachineTests
{
    public class when_product_purchased_with_more_money_than_purchase_price
    {
        private readonly VendingMachineProductSlot _slot;
        private readonly Domain.Aggregates.VendingMachine _vendingMachine;

        public when_product_purchased_with_more_money_than_purchase_price()
        {
            var product = FakeProductBuilder.New
                .WithPrice(new Money(50.0m))
                .Build();
            _slot = VendingMachineProductSlot.Create(product, new Quantity(5));

            _vendingMachine = Domain.Aggregates.VendingMachine.Create(
                productSlots: new VendingMachineProductSlot[] { _slot },
                moneyBox: Money.None);

            _vendingMachine.InsertMoney(new Money(70.0m));
            _vendingMachine.PurchaseProduct(_slot.Id);
        }

        [Test]
        public void then_stock_quantity_decremented()
        {
            var slot = _vendingMachine.GetSlot(_slot.Id).ShouldNotBeNull();
            slot.Stock.Value.ShouldBe((uint)4);
        }

        [Test]
        public void then_money_box_has_remainder()
        {
            _vendingMachine.MoneyBox.Amount.ShouldBe(20);
        }
    }
}
