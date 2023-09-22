using LES.Domain.Core.Data;
using LES.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LES.Infrastructure.Repository
{
    public class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly DataContext _dataContext;
        protected readonly DbSet<TEntity> _entity;
        public virtual IUnitOfWork UnitOfWork => _dataContext;

        public RepositoryBase(DataContext dataContext)
        {
            _dataContext = dataContext;
            _entity = _dataContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entity.Add(entity);
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return _entity;
        }

        public TEntity GetById(TKey id)
        {
            return _entity.Find(id);
        }

        public void Update(TEntity entity)
        {
            _entity.Update(entity);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await _dataContext.SaveChangesAsync().ConfigureAwait(false);
            return result;
        }
    }
}
