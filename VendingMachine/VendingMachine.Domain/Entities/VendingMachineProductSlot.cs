using VendingMachine.Domain.Exceptions;
using VendingMachine.Domain.Values;

namespace VendingMachine.Domain.Entities
{
    public class VendingMachineProductSlot : Entity
    {
        public VendingMachineProduct Product { get; private set; }
        public Quantity Stock { get; private set; }

        public VendingMachineProductSlot(
            Guid id,
            VendingMachineProduct product,
            Quantity stock) : base(id)
        {
            Product = product;
            Stock = stock;
        }

        public static VendingMachineProductSlot Create(
            VendingMachineProduct product,
            Quantity stock)
        {
            return new VendingMachineProductSlot(Guid.NewGuid(), product, stock);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="InsufficientStockException"></exception>
        public void Dispense()
        {
            if (Stock.Value is 0)
            {
                throw new InsufficientStockException();
            }
            Stock = Stock.Decrement();
        }
    }
}
