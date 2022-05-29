using System.Data.Common;

namespace DiggRestProfil.Infrastructure.Data
{
    public interface IUnitOfWork : IDisposable
    {
        DbConnection Connection { get; }
        DbTransaction? Transaction { get; }
        void Begin();
        void Commit();
        void Rollback();
        Task BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
