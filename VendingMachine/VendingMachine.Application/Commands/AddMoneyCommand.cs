using MediatR;

namespace VendingMachine.Application.Commands
{
    public class AddMoneyCommand : IRequest
    {
        public decimal Amount { get; private set; }

        public AddMoneyCommand(decimal amount)
        {
            Amount = amount;
        }
    }
}
