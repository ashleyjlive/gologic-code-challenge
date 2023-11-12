using Bogus;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Tests.Builders
{
    public class FakeProductBuilder
    {
        private static readonly Faker _faker = new();
        private string _name = _faker.Commerce.Product();
        private Money _price = new(decimal.Parse(_faker.Commerce.Price()));

        public static FakeProductBuilder New => new();

        public FakeProductBuilder WithPrice(Money price)
        {
            _price = price;
            return this;
        }

        public VendingMachineProduct Build()
        {
            return VendingMachineProduct.Create(
                name: _name,
                price: _price);
        }
    }
}
