using MediatR;
using VendingMachine.Application.Commands;
using VendingMachine.Infrastructure.Repositories.User;
using VendingMachine.Infrastructure.Repositories.VendingMachine;

namespace VendingMachine.Application.Handlers.Commands
{
    public class PurchaseProductCommandHandler : IRequestHandler<PurchaseProductCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IVendingMachineRepository _vendingMachineRepository;

        public PurchaseProductCommandHandler(
            IUserRepository userRepository,
            IVendingMachineRepository vendingMachineRepository)
        {
            _userRepository = userRepository;
            _vendingMachineRepository = vendingMachineRepository;
        }

        public Task Handle(PurchaseProductCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Get();
            var vendingMachine = _vendingMachineRepository.Get();

            var product = vendingMachine.PurchaseProduct(request.SlotId);
            user.AddProduct(product);

            _userRepository.Save(user);
            _vendingMachineRepository.Save(vendingMachine);

            return Task.CompletedTask;
        }
    }
}
