using Microsoft.EntityFrameworkCore;
using uow_repoSample.Models;

namespace uow_repoSample.Data
{
    public class SchoolDbContext:DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options):base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}