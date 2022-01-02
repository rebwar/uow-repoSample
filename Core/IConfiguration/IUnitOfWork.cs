using System.Threading.Tasks;
using uow_repoSample.Core.IRepositories;

namespace uow_repoSample.Core.IConfiguration
{
    public interface IUnitOfWork
    {
       public IStudentRepository Student { get; }  

       Task CompleteAsync();
    }
}