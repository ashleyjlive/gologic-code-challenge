using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Entities.VendingMachineProductTests
{
    internal class when_vending_machine_product_created
    {
        private readonly VendingMachineProduct _product;

        public when_vending_machine_product_created()
        {
            _product = VendingMachineProduct.Create(name: "Name", price: Money.FromAmount(10));
        }

        [Test]
        public void then_name_is_set()
        {
            _product.Name.ShouldBe("Name");
        }

        [Test]
        public void then_price_is_set()
        {
            _product.Price.Amount.ShouldBe(10);
        }
    }
}
