using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using uow_repoSample.Core.IConfiguration;
using uow_repoSample.Core.IRepositories;
using uow_repoSample.Core.Repositories;

namespace uow_repoSample.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IStudentRepository Student { get; private set; }
        private readonly SchoolDbContext _context;
        private readonly ILogger _logger;
        public UnitOfWork(SchoolDbContext context, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("log");
            _context = context;
            Student=new StudentRepository(_context,_logger);
        }

        public async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}