using MediatR;

namespace VendingMachine.Domain
{
    public abstract class DomainObject
    {
        public Guid Id { get; private set; }

        public DomainObject(Guid id)
        {
            Id = id;
        }
    }
}
