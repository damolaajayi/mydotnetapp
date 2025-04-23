using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetApp.Application.Interfaces.Repositories
{
    public interface IPasswordService
    {
        string Hash(string password);
        bool Verify(string hash, string password);
    }
}
