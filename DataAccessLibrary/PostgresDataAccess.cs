using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DataAccessLibrary
{
    public class PostgresDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;

        public PostgresDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConfigurationStringName { get; set; } = "Postgres";

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            var connectionString = _configuration.GetConnectionString(ConfigurationStringName);
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            var connectionString = _configuration.GetConnectionString(ConfigurationStringName);
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}