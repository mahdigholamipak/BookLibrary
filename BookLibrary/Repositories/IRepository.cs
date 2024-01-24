using System.Linq.Expressions;

namespace BookLibrary.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public TEntity Get(int Id);
        public Task<TEntity> GetAsync(int Id);

        public ICollection<TEntity> GetAll();
        public Task<ICollection<TEntity>> GetAllAsync();

        public ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        public Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        public void Add(TEntity entity);
        public Task AddAsync(TEntity entity);

        public void Update(TEntity entity);

        public void Remove(TEntity entity);
    }
}
