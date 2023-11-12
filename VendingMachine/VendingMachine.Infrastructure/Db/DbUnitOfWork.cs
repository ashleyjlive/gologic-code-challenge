using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using VendingMachine.Infrastructure.Configuration;

namespace VendingMachine.Infrastructure.Db
{
    public interface IUnitOfWork
    {
        public IDbTransaction? Transaction { get; }
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }

    public sealed class SqlDbUnitOfWork : IUnitOfWork, IDisposable
    {
        public SqlConnection Connection { get; private set; }
        public IDbTransaction? Transaction { get; private set; }

        public SqlDbUnitOfWork(IOptions<ConnectionStrings> configuration)
        {
            Connection = new SqlConnection(configuration.Value.DefaultConnection);
            Connection.Open();
        }

        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            Transaction?.Commit();
            Transaction = null;
        }

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }

        public void RollbackTransaction()
        {
            Transaction?.Rollback();
            Transaction = null;
        }
    }
}
