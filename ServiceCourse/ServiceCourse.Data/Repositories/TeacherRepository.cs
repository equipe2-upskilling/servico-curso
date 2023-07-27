using Dapper;
using Npgsql;
using ServiceCourse.Data.Context;
using ServiceCourse.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ServiceCourse.Data.Repositories
{
    public class TeacherRepository
    {
        public AcademicServiceDbContext context = new AcademicServiceDbContext();
        public Teacher GetTeacherById(int teacherId)
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM teachers WHERE id = @Id";
                return connection.QueryFirstOrDefault<Teacher>(sql, new { Id = teacherId });
            }
        }
        public List<Teacher> GetTeachers()
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM teachers";
                return connection.Query<Teacher>(sql).ToList();
            }
        }
    }
}
