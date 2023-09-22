using LES.Domain.Core.Data;

namespace LES.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Dispose() => _dataContext.Dispose();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
