using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace uow_repoSample.Core.IRepositories
{
    public interface IGenericRepository<T> where T:class
    {
         Task<IEnumerable<T>> All();

         Task<bool> Add(T entity);

         Task<bool> Update(T entity);

         Task<bool> Delete(Guid id);

         Task<T> Get(Guid id);
    }
}