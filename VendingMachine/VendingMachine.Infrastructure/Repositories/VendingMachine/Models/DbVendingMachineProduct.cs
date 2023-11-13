namespace VendingMachine.Infrastructure.Repositories.VendingMachine.Models
{
    internal class DbVendingMachineProduct
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public DbVendingMachineProduct(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
