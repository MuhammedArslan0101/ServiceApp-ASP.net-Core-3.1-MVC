using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ServiceApp.DataAccess.Data.Repository.IRepository
{
    // T : can be Category , Service , Order ....
     public interface IRepository <T> where T : class
    {
       T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        // Here is not necessary to call orderBy because its return one value
        T GetFirsOrDefault(
              Expression<Func<T, bool>> filter = null,
              string includeProperties = null
            );

        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);

    }
}
