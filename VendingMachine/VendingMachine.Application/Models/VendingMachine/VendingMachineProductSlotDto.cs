namespace VendingMachine.Application.Models.VendingMachine
{
    public record VendingMachineProductSlotDto(Guid Id, VendingMachineProductDto Product, uint Quantity);
}
