using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Values.QuantityTests
{
    public class when_product_stock_is_decremented
    {
        private readonly Quantity _quantity = new(1);

        public when_product_stock_is_decremented()
        {
            _quantity = _quantity.Decrement();
        }

        [Test]
        public void then_product_stock_quantity_should_be_decremented()
        {
            _quantity.Value.ShouldBe((uint)0);
        }
    }
}