using JWTSampleProject.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JWTSampleProject.Infrastructure.Base
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ISampleDbContext context;
        private readonly DbSet<T> dbSet;


        public BaseRepository(ISampleDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            //entity.CreatedAt = DateTime.Now;
            await dbSet.AddAsync(entity);
        }

        public async Task<int> Count(Expression<Func<T, bool>> filter)
        {
            return await dbSet.CountAsync(filter);
        }

        public virtual async Task<List<T>> GetAsync(
            Expression<Func<T, bool>> filter = null
           , Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
           , string includeProperties = ""
           , int? take = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (take != null)
                query = query.Take(take.Value);

            return await query.ToListAsync();
        }

        //Get By Pagination
        public virtual async Task<List<T>> GetByPagination(int pageSize,
                                                    int pageIndex,
                                                    Expression<Func<T, bool>> filter = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                    string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            try
            {
                if (orderBy != null)
                {
                    return await orderBy(query).Skip(pageSize * pageIndex).Take(pageSize).AsNoTracking().ToListAsync();
                }
                else
                {
                    return await query.Skip(pageSize * pageIndex).Take(pageSize).AsNoTracking().ToListAsync();
                }
            }
            catch (SqlException SX)
            {

                throw SX;
            }
        }

        public virtual async Task<T> GetFirstBy(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                //orderBy(query);
                query = orderBy(query);
            }

            return await query.FirstOrDefaultAsync();
        }

        //select just with quary
        public virtual IQueryable<T> Select(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }



        public async Task<T> GetByIdAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }


        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(long id)
        {
            T entityToDelete = await dbSet.FindAsync(id);
            Delete(entityToDelete);
        }
        private void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.CountAsync();
        }

        public async Task<T> GetById(object id)
        {
            var result = await dbSet.FindAsync(id);

            return result;
        }
    }
}
