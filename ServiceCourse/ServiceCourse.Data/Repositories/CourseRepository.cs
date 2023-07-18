using Dapper;
using Npgsql;
using ServiceCourse.Data.Context;
using ServiceCourse.Data.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ServiceCourse.Data.Repositories
{
    public class CourseRepository
    {
        public DataBaseContext context = new DataBaseContext();
        public Course GetCourseById(int id)
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM courses WHERE Id = @Id";
                return connection.QueryFirstOrDefault<Course>(sql, new { Id = id });
            }
        }
        public List<Course> GetCourses()
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM courses";
                return connection.Query<Course>(sql).ToList();
            }
        }

        public void CreateCourse(Course course)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(context.ConnectionString()))
            {
                string query = "INSERT INTO courses(Name, Description, Duration, Price, EnrollmentStatusId) " +
                    "VALUES (:Name, :Description, :Duration, :Price, :EnrollmentStatusId)";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Name", course.Name, DbType.String);
                parameters.Add("Description", course.Description, DbType.String);
                parameters.Add("Duration", course.Duration, DbType.Int32);
                parameters.Add("Price", course.Price, DbType.Int64);
                parameters.Add("EnrollmentStatusId", course.EnrollmentStatusId, DbType.Int32);

                connection.Execute(query, parameters);
            }
        }

        public void DeleteCourse(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(context.ConnectionString()))
            {
                string query = "DELETE FROM courses WHERE Id = :Id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                connection.Execute(query, parameters);
            }
        }

        public void UpdateCourse(Course course)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(context.ConnectionString()))
            {
                string query = "UPDATE courses " +
                    "set Name = @Name, " +
                    "Description = @Description " +
                    "Duration = @Duration " +
                    "Price = @Price " +
                    "EnrollmentStatusId = @EnrollmentStatusId " +
                    "WHERE Id = @Id";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", course.Id, DbType.Int32);
                parameters.Add("Name", course.Name, DbType.String);
                parameters.Add("Description", course.Description, DbType.String);
                parameters.Add("Duration", course.Duration, DbType.Int32);
                parameters.Add("Price", course.Price, DbType.Int64);
                parameters.Add("EnrollmentStatusId", course.EnrollmentStatusId, DbType.Int32);

                connection.Execute(query, parameters);
            }
        }
    }
}
