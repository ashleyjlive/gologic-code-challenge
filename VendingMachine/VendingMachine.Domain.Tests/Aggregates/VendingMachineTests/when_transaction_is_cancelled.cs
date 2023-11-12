using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Tests.Builders;
using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Aggregates.VendingMachineTests
{
    public class when_return_change_requested
    {
        private readonly VendingMachineProductSlot _slot;
        private readonly Domain.Aggregates.VendingMachine _vendingMachine;
        private readonly Money _refundAmount;

        public when_return_change_requested()
        {
            var product = FakeProductBuilder.New
                .WithPrice(new Money(50.0m))
                .Build();
            _slot = VendingMachineProductSlot.Create(product, new Quantity(5));

            _vendingMachine = Domain.Aggregates.VendingMachine.Create(
                moneyBox: Money.None,
                productSlots: new VendingMachineProductSlot[] { _slot });

            _vendingMachine.InsertMoney(new Money(30));
            _refundAmount = _vendingMachine.ReturnChange();
        }

        [Test]
        public void then_machine_money_reset()
        {
            _vendingMachine.MoneyBox.Amount.ShouldBe(0);
        }

        [Test]
        public void then_refund_money_is_correct()
        {
            _refundAmount.Amount.ShouldBe(30);
        }
    }
}
