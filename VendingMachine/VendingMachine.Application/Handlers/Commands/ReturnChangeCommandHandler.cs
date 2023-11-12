using MediatR;
using VendingMachine.Application.Commands;
using VendingMachine.Infrastructure.Repositories.User;
using VendingMachine.Infrastructure.Repositories.VendingMachine;

namespace VendingMachine.Application.Handlers.Commands
{
    public class ReturnChangeCommandHandler : IRequestHandler<ReturnChangeCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IVendingMachineRepository _vendingMachineRepository;

        public ReturnChangeCommandHandler(IUserRepository userRepository, IVendingMachineRepository vendingMachineRepository)
        {
            _userRepository = userRepository;
            _vendingMachineRepository = vendingMachineRepository;
        }

        public Task Handle(ReturnChangeCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Get();
            var vendingMachine = _vendingMachineRepository.Get();

            var money = vendingMachine.ReturnChange();
            user.AddMoney(money);

            _userRepository.Save(user);
            _vendingMachineRepository.Save(vendingMachine);

            return Task.CompletedTask;
        }
    }
}
