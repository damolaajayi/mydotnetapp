using Microsoft.AspNetCore.Identity;
using MyDotNetApp.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyDotNetApp.Infrastructure.Security.PasswordService;

namespace MyDotNetApp.Infrastructure.Security
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<string> _hasher = new();
        public string Hash(string password) => _hasher.HashPassword(null, password);

        public bool Verify(string hash, string password) =>
            _hasher.VerifyHashedPassword(null, hash, password) == PasswordVerificationResult.Success;
    }
}
