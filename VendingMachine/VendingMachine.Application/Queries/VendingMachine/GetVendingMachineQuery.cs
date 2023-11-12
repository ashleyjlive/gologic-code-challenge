using MediatR;
using VendingMachine.Application.Models.VendingMachine;

namespace VendingMachine.Application.Queries.VendingMachine
{
    public class GetVendingMachineQuery : IRequest<VendingMachineDto>
    {
    }
}
