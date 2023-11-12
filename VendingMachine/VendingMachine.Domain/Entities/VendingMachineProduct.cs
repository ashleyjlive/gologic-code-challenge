using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Entities
{
    public class VendingMachineProduct : Entity
    {
        public string Name { get; private set; }
        public Money Price { get; private set; }

        public VendingMachineProduct(Guid id, string name, Money price) : base(id)
        {
            Name = name;
            Price = price;
        }

        public static VendingMachineProduct Create(string name, Money price)
        {
            return new VendingMachineProduct(Guid.NewGuid(), name, price);
        }
    }
}
