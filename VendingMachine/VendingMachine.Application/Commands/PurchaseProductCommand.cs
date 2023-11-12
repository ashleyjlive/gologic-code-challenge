using MediatR;

namespace VendingMachine.Application.Commands
{
    public class PurchaseProductCommand : IRequest
    {
        public Guid SlotId { get; private set; }

        public PurchaseProductCommand(Guid slotId)
        {
            SlotId = slotId;
        }
    }
}
