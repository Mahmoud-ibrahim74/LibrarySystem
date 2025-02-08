using System.Linq.Expressions;
namespace LibrarySystem.DataAccess.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {

        public Task<T> GetByIdAsync(int id);

        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null!,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!, Expression<Func<T, bool>> includeFilter = null!,
         string includeProperties = null!,
         int? skip = null,
         int? take = null);


        Task<IEnumerable<TType>> GetSpecificSelectAsync<TType>(
                    Expression<Func<T, bool>> filter,
                    Expression<Func<T, TType>> select,
                    string includeProperties = null!,
                    int? skip = null,
                    int? take = null,
                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!) where TType : class;
        public Task<bool> ExistAsync(int id);

        public Task<bool> ExistAsync(Expression<Func<T, bool>> filter = null!, string includeProperties = null!
          );

        public Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null!,
            string includeProperties = null!

            );


        public Task<T> AddAsync(T entity);

        public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        public T Remove(T entity);

        public T Update(T entity);

        public Task<int> CountAsync(Expression<Func<T, bool>> filter = null!, string includeProperties = null!);

        public Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null!);

        public void RemoveRange(IEnumerable<T> entities);

        public void UpdateRange(IEnumerable<T> entities);


        public Task<int> MaxInCloumn(Expression<Func<T, int>> selector);
    }
}
