using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using uow_repoSample.Core.IRepositories;
using uow_repoSample.Data;

namespace uow_repoSample.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SchoolDbContext _context;
        protected DbSet<T> _dbSet;
        protected readonly ILogger _logger;
        public GenericRepository(SchoolDbContext context, ILogger logger)
        {
           _logger = logger;
            _context = context;
            _dbSet=_context.Set<T>();

        }
        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> Get(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}