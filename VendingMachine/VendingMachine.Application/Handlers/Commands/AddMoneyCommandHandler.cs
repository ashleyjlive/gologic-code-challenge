using MediatR;
using VendingMachine.Application.Commands;
using VendingMachine.Domain.Values;
using VendingMachine.Infrastructure.Db;
using VendingMachine.Infrastructure.Repositories.User;
using VendingMachine.Infrastructure.Repositories.VendingMachine;

namespace VendingMachine.Application.Handlers.Commands
{
    public class AddMoneyCommandHandler : IRequestHandler<AddMoneyCommand>
    {
      //  private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IVendingMachineRepository _vendingMachineRepository;

        public AddMoneyCommandHandler(
            //IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IVendingMachineRepository vendingMachineRepository)
        {
           // _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _vendingMachineRepository = vendingMachineRepository;
        }

        public Task Handle(AddMoneyCommand request, CancellationToken cancellationToken)
        {
            try
            {
           //     _unitOfWork.BeginTransaction();
                var user = _userRepository.Get();
                var vendingMachine = _vendingMachineRepository.Get();

                var money = Money.FromAmount(request.Amount);
                user.DeductMoney(money);
                vendingMachine.InsertMoney(money);

                _userRepository.Save(user);
                _vendingMachineRepository.Save(vendingMachine);

     //           _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
   //             _unitOfWork.RollbackTransaction();
                throw;
            }

            return Task.CompletedTask;
        }
    }
}
