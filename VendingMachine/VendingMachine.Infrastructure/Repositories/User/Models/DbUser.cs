using VendingMachine.Infrastructure.Repositories.VendingMachine.Models;

namespace VendingMachine.Infrastructure.Repositories.User.Models
{
    internal class DbUser
    {
        public Guid Id { get; private set; }
        public decimal Money { get; private set; }
        public List<DbVendingMachineProduct> Products { get; private set; }

        public DbUser(Guid id, decimal money, List<DbVendingMachineProduct> products)
        {
            Id = id;
            Money = money;
            Products = products;
        }
    }
}
