using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Aggregates.VendingMachineTests
{
    public class when_money_is_inserted
    {
        private readonly Domain.Aggregates.VendingMachine _vendingMachine;

        public when_money_is_inserted()
        {
            _vendingMachine = Domain.Aggregates.VendingMachine.Create(
                moneyBox: Money.None,
                productSlots: Array.Empty<VendingMachineProductSlot>());

            _vendingMachine.InsertMoney(new Money(20));
            _vendingMachine.InsertMoney(new Money(30));
        }

        public void then_transaction_money_is_updated()
        {
            _vendingMachine.MoneyBox.Amount.ShouldBe(50);
        }
    }
}
