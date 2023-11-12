using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Values.MoneyTests
{
    public class when_money_is_added
    {
        private readonly Money _money = new(50.5m);

        public when_money_is_added()
        {
            _money = _money.Add(new Money(20.3m));
        }

        [Test]
        public void then_money_value_is_added()
        {
            _money.Amount.ShouldBe(70.8m);
        }
    }
}