using System.Threading.Tasks;

namespace UserService.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserServiceDbContext _dbContext;
        public UnitOfWork(UserServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}