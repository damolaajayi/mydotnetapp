using MyDotNetApp.Application.Common.Response;
using MyDotNetApp.Application.DTOs;
using MyDotNetApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetApp.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<ApiResponse> CreateUserAsync(UserDto userdto);
        Task<ApiResponse> GetAllAsync();

        Task<bool> UserNameExistsAsync(string username);
        Task<bool> EmailExistsAsync(string email);
    }
}
