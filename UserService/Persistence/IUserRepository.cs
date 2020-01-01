using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Persistence
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(Guid id);
        Task AddUser(User user);
        Task<User> DeleteUser(Guid id);
        Task UpdateUser(User user);
    }
}