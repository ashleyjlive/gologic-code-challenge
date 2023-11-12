using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Values.QuantityTests
{
    public class when_product_stock_is_incremented
    {
        private readonly Quantity _quantity = new(0);

        public when_product_stock_is_incremented()
        {
            _quantity = _quantity.Increment();
        }

        [Test]
        public void then_product_stock_quantity_should_be_incremented()
        {
            _quantity.Value.ShouldBe((uint)1);
        }
    }
}