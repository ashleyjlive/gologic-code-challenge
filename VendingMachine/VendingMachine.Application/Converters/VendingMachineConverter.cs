using VendingMachine.Application.Models.VendingMachine;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Converters
{
    public static class VendingMachineConverter
    {
        public static VendingMachineDto ToDTO(this Domain.Aggregates.VendingMachine vendingMachine)
        {
            return new VendingMachineDto(vendingMachine.MoneyBox.Amount, vendingMachine.ProductSlots.Select(ToDTO));
        }

        public static VendingMachineProductSlotDto ToDTO(this VendingMachineProductSlot vendingMachineProductSlot)
        {
            return new VendingMachineProductSlotDto(vendingMachineProductSlot.Id, ToDTO(vendingMachineProductSlot.Product), vendingMachineProductSlot.Stock.Value);
        }

        public static VendingMachineProductDto ToDTO(this VendingMachineProduct vendingMachineProduct)
        {
            return new VendingMachineProductDto(vendingMachineProduct.Id, vendingMachineProduct.Name, vendingMachineProduct.Price.Amount);
        }
    }
}
