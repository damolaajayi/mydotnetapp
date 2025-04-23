using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetApp.Infrastructure.Data.DbContexts
{
    public interface IDapperDbContext
    {
        IDbConnection CreateConnection();
    }
}
