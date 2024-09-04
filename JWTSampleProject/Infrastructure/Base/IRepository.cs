using System.Linq.Expressions;

namespace JWTSampleProject.Infrastructure.Base
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);

        Task<List<T>> GetByPagination(int pageSize,
                                                 int pageIndex,
                                                 Expression<Func<T, bool>> filter = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                 string includeProperties = "");
        Task<List<T>> GetAsync(Expression<Func<T, bool>> filter = null,
                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                string includeProperties = "", int? take = null);

        Task<T> GetFirstBy(Expression<Func<T, bool>> filter = null,
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                            string includeProperties = "");

        IQueryable<T> Select(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        Task<T> GetByIdAsync(long id);
        void Update(T entity);
        Task DeleteAsync(long id);
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);

        Task<int> Count(Expression<Func<T, bool>> filter);

        Task<T> GetById(object id);
    }
}
