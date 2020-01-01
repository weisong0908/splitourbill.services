using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserService.Models;

namespace UserService.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly UserServiceDbContext _dbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(UserServiceDbContext dbContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = new List<User>();

            try
            {
                users = await _dbContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all users");
            }

            return users;
        }

        public async Task<User> GetUser(Guid id)
        {
            User user = null;

            try
            {
                user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user with Id {id}.", id);
            }

            if (user == null)
                _logger.LogError("User with Id: {id} is not found.", id);

            return user;
        }

        public async Task AddUser(User user)
        {
            if (await _dbContext.Users.CountAsync(u => u.Username == user.Username) > 0)
                throw new Exception($"User with username {user.Username} already exists.");

            await _dbContext.Users.AddAsync(user);
        }

        public async Task<User> DeleteUser(Guid id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user == null)
                throw new Exception($"User with Id {id} is not found.");

            _dbContext.Remove(user);

            return user;
        }

        public async Task UpdateUser(User user)
        {
            if (await _dbContext.Users.CountAsync(u => u == user) == 0)
                throw new Exception($"User with Id {user.Id} is not found.");

            _dbContext.Entry(user).State = EntityState.Modified;
        }
    }
}