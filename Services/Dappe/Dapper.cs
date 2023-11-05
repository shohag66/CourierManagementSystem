using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace CourierManagementSystem.Services.Dappe
{
    public class Dapper : IDapper
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "CourierManagementConnection";

        public Dapper(IConfiguration config)
        {
            _config = config;
        }
        public void Dispose()
        {

        }

        public async Task<List<T>> FromSql<T>(string SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            var result = await db.QueryAsync<T>(SqlQuery, commandType: commandType);
            return result.ToList();
        }

        public async Task<T> FromSqlFirstOrDefaultAsync<T>(string SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            var result = await db.QueryFirstOrDefaultAsync<T>(SqlQuery, commandType: commandType);
            return result;
        }

        public T FromSqlFirstOrDefault<T>(string SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            var result = db.QueryFirstOrDefault<T>(SqlQuery, commandType: commandType);
            return result;
        }

        public async Task<T> FromSqlSingleOrDefaultAsync<T>(string SqlQuery, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            var result = await db.QuerySingleOrDefaultAsync<T>(SqlQuery, commandType: commandType);
            return result;
        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }



        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(Connectionstring));
        }

       
    }
}
