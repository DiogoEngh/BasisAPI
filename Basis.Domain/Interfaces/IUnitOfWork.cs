namespace Basis.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Rollback();
        Task RollbackAsync(CancellationToken cancellationToken = default);
        int SaveEntities();
        Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
