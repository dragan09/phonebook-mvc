using phonebook.core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phonebook.data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity :class;
        int SaveChanges();
    }
}
