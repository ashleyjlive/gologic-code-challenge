using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Values;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.Aggregates
{
    public class VendingMachine : Aggregate
    {
        private readonly List<VendingMachineProductSlot> _productSlots;
        public IReadOnlyList<VendingMachineProductSlot> ProductSlots => _productSlots.AsReadOnly();
        public Money MoneyBox { get; private set; }

        public VendingMachine(Guid id, IEnumerable<VendingMachineProductSlot> productSlots, Money moneyBox) : base(id)
        {
            _productSlots = productSlots.ToList();
            MoneyBox = moneyBox;
        }

        public void InsertMoney(Money amount)
        {
            MoneyBox = MoneyBox.Add(amount);
        }

        public Money ReturnChange()
        {
            var change = MoneyBox;
            MoneyBox = Money.None;
            return change;
        }

        public VendingMachineProductSlot? GetSlot(Guid slotId)
        {
            return _productSlots.SingleOrDefault(slot => slot.Id == slotId);
        }

        public VendingMachineProduct PurchaseProduct(Guid slotId)
        {
            if (GetSlot(slotId) is not VendingMachineProductSlot slot)
            {
                throw new ProductSlotNotFoundException();
            }
            MoneyBox = MoneyBox.Deduct(slot.Product.Price);
            slot.Dispense();
            return slot.Product;
        }

        public static VendingMachine Create(IEnumerable<VendingMachineProductSlot> productSlots, Money moneyBox)
        {
            return new VendingMachine(Guid.NewGuid(), productSlots, moneyBox);
        }
    }
}
