using Dapper;
using Npgsql;
using ServiceCourse.Data.Context;
using ServiceCourse.Data.Entities;

namespace ServiceCourse.Data.Repositories
{
    public class LoginRepository
    {
        public DataBaseContext context = new DataBaseContext();

        public Login GetLogin(string email, string password)
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM users WHERE email = @email and password = @password";
                return connection.QueryFirstOrDefault<Login>(sql, new { Email = email, Password = password });
            }
        }

        public Login GetuserByEmail(string email)
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM users WHERE email = @email";
                return connection.QueryFirstOrDefault<Login>(sql, new { Email = email });
            }
        }
    }
}
