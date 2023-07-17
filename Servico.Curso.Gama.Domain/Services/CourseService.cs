using Service.CourseGama.Data.Entity;
using Service.CourseGama.Data.Repository;
using Servico.Curso.Gama.Domain.Model;
using System.Collections.Generic;

namespace Service.CourseGama.Domain.Services
{
    public class CourseService
    {
        public CourseRepository _repository = new CourseRepository();

        public Course GetCourseById(int Id)
        {
            return _repository.GetCourseById(Id);
        }

        public List<Course> GetCourses()
        {
            return _repository.GetCourses();
        }

        public void CreateCourse(CourseModel courseModel)
        {
            Course course = new Course()
            {
                Name = courseModel.Name,
                Description = courseModel.Description,
                Duration = courseModel.Duration,
                Price = courseModel.Price,
                EnrollmentStatusId = (int)CourseModel.EnrollmentStatus.Aguardando
            };

            _repository.CreateCourse(course);
        }

        public void UpdateCourse(CourseModel courseModel)
        {
            Course course = new Course()
            {
                Name = courseModel.Name,
                Description = courseModel.Description,
                Duration = courseModel.Duration,
                Price = courseModel.Price,
                EnrollmentStatusId = (int)courseModel.Status
            };

            _repository.UpdateCourse(course);

        }

        public void DeleteCourse(int Id)
        {
            _repository.DeleteCourse(Id);
        }
    }
}
