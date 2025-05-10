using MySql.Data.MySqlClient;
using System.Data;

namespace MyApi.Data
{
    public class DbContextDapper
    {
        private readonly IConfiguration _config;
        public DbContextDapper(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection CreateConnection() =>
            new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
    }

}
