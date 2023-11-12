using MediatR;
using VendingMachine.Application.Converters;
using VendingMachine.Application.Models.VendingMachine;
using VendingMachine.Application.Queries.VendingMachine;
using VendingMachine.Infrastructure.Repositories.VendingMachine;

namespace VendingMachine.Application.Handlers.Queries
{
    public class GetVendingMachineQueryHandler : IRequestHandler<GetVendingMachineQuery, VendingMachineDto>
    {
        private readonly IVendingMachineRepository _vendingMachineRepository;

        public GetVendingMachineQueryHandler(IVendingMachineRepository vendingMachineRepository)
        {
            _vendingMachineRepository = vendingMachineRepository;
        }

        public Task<VendingMachineDto> Handle(GetVendingMachineQuery request, CancellationToken cancellationToken)
        {
            var vendingMachine = _vendingMachineRepository.Get();
            return Task.FromResult(vendingMachine.ToDTO());
        }
    }
}
