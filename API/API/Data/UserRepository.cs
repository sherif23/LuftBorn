using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;

        public UserRepository (DataContext dataContext)
        {
            this.context = dataContext;
        }

        public async Task<User> AddNewUser(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task <bool> DeleteUser(int id)
        {
            User user = await GetUser(id);
            if (user == null) return false;
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUser(int id)
        {
         
            return await context.Users.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return user;
        }
    }
}
