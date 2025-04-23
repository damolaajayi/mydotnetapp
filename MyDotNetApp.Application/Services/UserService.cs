using Microsoft.EntityFrameworkCore;
using MyDotNetApp.Application.Common.Response;
using MyDotNetApp.Application.DTOs;
using MyDotNetApp.Application.Interfaces.Repositories;
using MyDotNetApp.Application.Interfaces.Services;
using MyDotNetApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyDotNetApp.Application.Services
{
    public class UserService(IUserRepository userRepository, IPasswordService passwordService) : IUserService
    {

        public async Task<ApiResponse> CreateUserAsync(UserDto userdto)
        {
            var resp = new ApiResponse();
            try
            {
                if (await EmailExistsAsync(userdto.Email))
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Email already exists"
                    };
                }

                if (await UserNameExistsAsync(userdto.Username))
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Username already exists"
                    };
                }

                var hashedPassword = passwordService.Hash(userdto.Password);

                var user = new User
                {
                    FirstName = userdto.FirstName,
                    LastName = userdto.LastName,
                    Email = userdto.Email,
                    MiddleName = userdto.MiddleName,
                    Gender = userdto.Gender,
                    Username = userdto.Username,
                    Password = hashedPassword,
                    Roles = userdto.Roles
                };

                var adduser = await userRepository.AddUser(user);

                if (adduser)
                {
                    return new ApiResponse
                    {
                        Success = true,
                        Message = "User created successfully" 
                    };
                }
                else
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Failed to create user"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }


        public async Task<bool> EmailExistsAsync(string email)
        {
            return await userRepository.EmailExistsAsync(email);
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            var resp = new ApiResponse();
            try
            {
                var getallusers = await userRepository.GetUsers();
                if (getallusers.Any())
                {
                    resp.Success = true;
                    resp.Message = "Success";
                    resp.Data = getallusers;
                    return resp;
                }
                else
                {
                    resp.Success = false;
                    resp.Message = "Not Users found";
                    return resp;

                }
            }
            catch (Exception ex)
            {
                resp.Success = false;
                resp.Message = $"An error occurred {ex.Message} {ex.StackTrace}";
                return resp;
            }
            
        }

        public async Task<bool> UserNameExistsAsync(string username)
        {
            return await userRepository.UserNameExistsAsync(username);
        }
    }
}
