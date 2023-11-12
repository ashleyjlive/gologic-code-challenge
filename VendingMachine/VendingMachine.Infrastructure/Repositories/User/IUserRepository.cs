namespace VendingMachine.Infrastructure.Repositories.User
{
    public interface IUserRepository
    {
        Domain.Aggregates.User Get();
        void Save(Domain.Aggregates.User user);
    }
}
