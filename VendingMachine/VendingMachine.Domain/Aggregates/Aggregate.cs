namespace VendingMachine.Domain.Aggregates
{
    public abstract class Aggregate : DomainObject
    {
        public Aggregate(Guid id) : base(id) { }
    }
}
