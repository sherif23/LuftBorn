using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IUserRepository
    {

        Task<User> AddNewUser(User user);

        Task<User> UpdateUser(User user);

        Task<bool> DeleteUser(int id);

        Task<User> GetUser(int id);

        Task<List<User>> GetUsers();
    }
}
