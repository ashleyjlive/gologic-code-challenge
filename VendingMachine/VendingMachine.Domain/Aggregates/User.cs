using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Aggregates
{
    public class User : Aggregate
    {
        private List<VendingMachineProduct> _products;
        public Money Money { get; private set; }
        public IReadOnlyList<VendingMachineProduct> Products => _products.AsReadOnly();
        
        public User(Guid id, Money money, IEnumerable<VendingMachineProduct> products) : base(id)
        {
            _products = products.ToList();
            Money = money;
        }

        public void AddMoney(Money money)
        {
            Money = Money.Add(money);
        }

        public void DeductMoney(Money money)
        {
            Money = Money.Deduct(money);
        }

        public void AddProduct(VendingMachineProduct product)
        {
            _products.Add(product);
        }

        public static User Create(Money money, IEnumerable<VendingMachineProduct> products)
        {
            return new User(Guid.NewGuid(), money, products);
        }
    }
}
