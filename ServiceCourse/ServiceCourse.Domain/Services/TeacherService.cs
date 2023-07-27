using ServiceCourse.Data.Repositories;
using ServiceCourse.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceCourse.Domain.Services
{
    public class TeacherService
    {
        public TeacherRepository _repository = new TeacherRepository();
        public TeacherModel GetTeacherById(int teacherId)
        {
            var teacher = _repository.GetTeacherById(teacherId);

            var teacherModel = new TeacherModel()
            {
                Id = teacher.Id,
                TeacherName = teacher.Name,
                Active = teacher.Active,
            };

            return teacherModel;
        }
        public List<TeacherModel> GetTeachers()
        {
            var teachers = _repository.GetTeachers();

            var teachersModel = teachers.Select(x => new TeacherModel()
            {
                Id = x.Id,
                TeacherName = x.Name,
                Active = x.Active,
            }).ToList();

            return teachersModel;
        }
    }
}
