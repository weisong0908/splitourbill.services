using System.Threading.Tasks;

namespace UserService.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}