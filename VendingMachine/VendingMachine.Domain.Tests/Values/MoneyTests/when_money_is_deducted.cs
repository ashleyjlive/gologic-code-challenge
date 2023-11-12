using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Values.MoneyTests
{
    public class when_money_is_deducted
    {
        private readonly Money _money = new(50.5m);

        public when_money_is_deducted()
        {
            _money = _money.Deduct(new Money(20.3m));
        }

        [Test]
        public void then_money_value_is_deducted()
        {
            _money.Amount.ShouldBe(30.2m);
        }
    }
}