namespace VendingMachine.Infrastructure.Repositories.VendingMachine.Models
{
    internal class DbVendingMachineProductSlot
    {
        public Guid Id { get; private set; }
        public DbVendingMachineProduct Product { get; private set; }
        public uint Quantity { get; private set; }

        public DbVendingMachineProductSlot(Guid id, DbVendingMachineProduct product, uint quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }
    }
}
