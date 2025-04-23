using MyDotNetApp.Application.DTOs;
using MyDotNetApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetApp.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddUser(User user);

        Task<List<User>> GetUsers();
        Task<User?> GetByIdAsync(int id);
        Task<bool> UserNameExistsAsync(string username);
        Task<bool> EmailExistsAsync(string email);
    }
}
