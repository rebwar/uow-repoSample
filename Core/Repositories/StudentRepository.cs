using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using uow_repoSample.Core.IRepositories;
using uow_repoSample.Data;
using uow_repoSample.Models;

namespace uow_repoSample.Core.Repositories
{
    public class StudentRepository:GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolDbContext context,ILogger logger):base(context,logger)
        {
            
        }

        public async override Task<IEnumerable<Student>> All()
        {
            try
            {
                 return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex,"{0} All method error",typeof(StudentRepository));
                return new List<Student>();
            }
        }

        public async override Task<bool> Update(Student entity)
        {
           try
           {
                 var existUser=await _dbSet.Where(x=>x.Id==entity.Id).FirstOrDefaultAsync();
                 if(existUser is null)
                    return await Add(entity);
                existUser.FirstName=entity.FirstName;
                existUser.Lastname=entity.Lastname;
                existUser.Email=entity.Email;
                return true;

           }
           catch (Exception ex)
           {
               
              _logger.LogError(ex,"{0} Update Method error",typeof(StudentRepository));
              return false;
           }
        }
    }
}