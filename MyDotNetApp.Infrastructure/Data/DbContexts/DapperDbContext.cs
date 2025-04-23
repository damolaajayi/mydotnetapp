using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace MyDotNetApp.Infrastructure.Data.DbContexts
{
    public class DapperDbContext : IDapperDbContext
    {
        private readonly string _connectionString;
        public DapperDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Missing DB connection");
        }
        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    }
}
