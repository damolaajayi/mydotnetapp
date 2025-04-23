using Microsoft.EntityFrameworkCore;
using MyDotNetApp.Application.Interfaces.Repositories;
using MyDotNetApp.Domain.Entities;
using MyDotNetApp.Infrastructure.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetApp.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext db) : IUserRepository
    {
        public async Task<bool> AddUser(User user)
        {
            await db.Users.AddAsync(user);
            var result = await db.SaveChangesAsync();
            return result > 0; // Returns the number of affected rows
        }

        public async Task<bool> EmailExistsAsync(string email) =>
            await db.Users.AnyAsync(u => u.Email == email);

        public async Task<User?> GetByIdAsync(int id) =>
            await db.Users.FindAsync(id);

        public async Task<List<User>> GetUsers() =>
            await db.Users.ToListAsync();

        public async Task<bool> UserNameExistsAsync(string username) =>
        await db.Users.AnyAsync(u => u.Username == username);
    }
}
