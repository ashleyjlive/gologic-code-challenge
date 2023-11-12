using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Values;

namespace VendingMachine.Infrastructure.Repositories.VendingMachine
{
    public class VendingMachineRepository : IVendingMachineRepository
    {
        private Domain.Aggregates.VendingMachine _vendingMachine;

        public VendingMachineRepository()
        {
            _vendingMachine = Domain.Aggregates.VendingMachine.Create(new List<VendingMachineProductSlot>()
            {
                VendingMachineProductSlot.Create(VendingMachineProduct.Create("Product", Money.FromAmount(50)), Quantity.FromValue(5))
            }, Money.None);
        }

        public Domain.Aggregates.VendingMachine Get()
        {
            return _vendingMachine;
        }

        public void Save(Domain.Aggregates.VendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
        }
    }
}
