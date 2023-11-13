namespace VendingMachine.Infrastructure.Repositories.VendingMachine.Models
{
    internal class DbVendingMachine
    {
        public Guid Id { get; private set; }
        public decimal Money { get; private set; }
        public List<DbVendingMachineProductSlot> Slots { get; private set; }

        public DbVendingMachine(Guid id, decimal money, List<DbVendingMachineProductSlot> slots)
        {
            Id = id;
            Money = money;
            Slots = slots;
        }
    }
}
