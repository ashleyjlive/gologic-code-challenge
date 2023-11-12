namespace VendingMachine.Infrastructure.Repositories.VendingMachine
{
    public interface IVendingMachineRepository
    {
        Domain.Aggregates.VendingMachine Get();
        void Save(Domain.Aggregates.VendingMachine vendingMachine);
    }
}
