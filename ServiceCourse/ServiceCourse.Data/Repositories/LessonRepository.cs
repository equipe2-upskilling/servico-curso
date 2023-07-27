using Dapper;
using Npgsql;
using ServiceCourse.Data.Context;
using ServiceCourse.Data.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ServiceCourse.Data.Repositories
{
    public class LessonRepository
    {
        public DataBaseContext context = new DataBaseContext();
        public Lesson GetLessonById(int lessonId)
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM lessons WHERE lessonid = @Id";
                return connection.QueryFirstOrDefault<Lesson>(sql, new { Id = lessonId });
            }
        }
        public List<Lesson> GetLessons()
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM lessons";
                return connection.Query<Lesson>(sql).ToList();
            }
        }

        public List<Lesson> GetLessonsByCourseId(int courseId)
        {
            using (var connection = new NpgsqlConnection(context.ConnectionString()))
            {
                connection.Open();
                var sql = "SELECT * FROM lessons WHERE courseid = @Id";
                return connection.Query<Lesson>(sql, new { Id = courseId }).ToList();
            }
        }

        public void CreateLesson(Lesson lesson)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(context.ConnectionString()))
            {
                string query = "INSERT INTO lessons(CourseId, Name, Description, LessonUrl, Image) " +
                    "VALUES (:CourseId, :Name, :Description, :LessonUrl, :Image)";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("CourseId", lesson.CourseId, DbType.Int32);
                parameters.Add("Name", lesson.Name, DbType.String);
                parameters.Add("Description", lesson.Description, DbType.String);
                parameters.Add("LessonUrl", lesson.LessonUrl, DbType.String);
                parameters.Add("Image", lesson.Image, DbType.String);
   
                connection.Execute(query, parameters);
            }
        }

        public void DeleteLesson(int lessonId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(context.ConnectionString()))
            {
                string query = "DELETE FROM lessons WHERE lessonid = :lessonId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("lessonId", lessonId, DbType.Int32);

                connection.Execute(query, parameters);
            }
        }

        public void UpdateLesson(Lesson lesson)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(context.ConnectionString()))
            {
                string query = "UPDATE lessons " +
                    "set Name = @Name, " +
                    "Description = @Description, " +
                    "LessonUrl = @LessonUrl, " +
                    "Image = @Image " +
                    "WHERE lessonid = @LessonId";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("LessonId", lesson.LessonId, DbType.Int32);
                //parameters.Add("CourseId", lesson.CourseId, DbType.Int32);
                parameters.Add("Name", lesson.Name, DbType.String);
                parameters.Add("Description", lesson.Description, DbType.String);
                parameters.Add("LessonUrl", lesson.LessonUrl, DbType.String);
                parameters.Add("Image", lesson.Image, DbType.String);

                connection.Execute(query, parameters);
            }
        }
    }
}
