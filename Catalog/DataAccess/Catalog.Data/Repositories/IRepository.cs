using Catalog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<IList<T>> GetAll();
        Task Add(T entity);
    }
}
