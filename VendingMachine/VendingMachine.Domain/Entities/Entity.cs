namespace VendingMachine.Domain.Entities
{
    public abstract class Entity : DomainObject
    {
        public Entity(Guid id) : base(id) { }
    }
}
