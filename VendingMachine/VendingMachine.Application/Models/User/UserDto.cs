using VendingMachine.Application.Models.VendingMachine;

namespace VendingMachine.Application.Models.User
{
    public record UserDto(Guid Id, decimal Money, List<VendingMachineProductDto> Products);
}
