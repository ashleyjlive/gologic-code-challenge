namespace VendingMachine.Application.Models.VendingMachine
{
    public record VendingMachineDto(decimal Money, IEnumerable<VendingMachineProductSlotDto> Slots);
}
