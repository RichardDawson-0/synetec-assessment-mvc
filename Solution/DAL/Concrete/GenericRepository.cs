using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext _db;
        private DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            this._db = context;
            this._dbSet = context.Set<T>();
        }
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);
            return query;
        }
    }
}
