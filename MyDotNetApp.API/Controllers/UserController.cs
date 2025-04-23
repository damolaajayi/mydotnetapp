using Microsoft.AspNetCore.Mvc;
using MyDotNetApp.Application.Common.Response;
using MyDotNetApp.Application.DTOs;
using MyDotNetApp.Application.Interfaces.Services;
using MyDotNetApp.Domain.Entities;

namespace MyDotNetApp.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("adduser")]
        public async Task<ActionResult> AddUser(UserDto userDto)
        {
            var adduser = await userService.CreateUserAsync(userDto);
            return Ok(adduser);
        }


        [HttpPost("getusers")]
        public async Task<ActionResult> GetUsers()
        {
            var adduser = await userService.GetAllAsync();
            return Ok(adduser);
        }
    }
}
