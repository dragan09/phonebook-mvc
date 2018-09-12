using phonebook.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace phonebook.data
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        IQueryable<T> Get(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "");
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
        IQueryable<T> Table { get; }
    }
}
