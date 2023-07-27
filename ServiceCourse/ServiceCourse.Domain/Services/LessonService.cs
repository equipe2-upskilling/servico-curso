using ServiceCourse.Data.Entities;
using ServiceCourse.Data.Repositories;
using ServiceCourse.Domain.Models;
using System.Collections.Generic;

namespace ServiceCourse.Domain.Services
{
    public class LessonService
    {
        public LessonRepository _repository = new LessonRepository();

        public LessonModel GetLessonById(int Id)
        {
            var lesson = _repository.GetLessonById(Id);

            var lessonModel = new LessonModel()
            {
                LessonId = lesson.LessonId,
                CourseId = lesson.CourseId,
                Name = lesson.Name,
                Description = lesson.Description,
                LessonUrl = lesson.LessonUrl,
                Image = lesson.Image,
            };

            return lessonModel;
        }

        public List<LessonModel> GetLessons()
        {
            var lessons = _repository.GetLessons();
            List<LessonModel> lessonsModel = new List<LessonModel>();

            foreach (var lesson in lessons)
            {
                lessonsModel.Add(new LessonModel
                {
                    LessonId = lesson.LessonId,
                    CourseId = lesson.CourseId,
                    Name = lesson.Name,
                    Description = lesson.Description,
                    LessonUrl = lesson.LessonUrl,
                    Image = lesson.Image,
                });
            }

            return lessonsModel;
        }

        public List<LessonModel> GetLessonsByCourseId(int courseId)
        {
            var lessons = _repository.GetLessonsByCourseId(courseId);
            List<LessonModel> lessonsModel = new List<LessonModel>();

            foreach (var lesson in lessons)
            {
                lessonsModel.Add(new LessonModel
                {
                    LessonId = lesson.LessonId,
                    CourseId = lesson.CourseId,
                    Name = lesson.Name,
                    Description = lesson.Description,
                    LessonUrl = lesson.LessonUrl,
                    Image = lesson.Image,
                });
            }

            return lessonsModel;
        }

        public void CreateLesson(LessonModel lessonModel)
        {
            Lesson lesson = new Lesson()
            {
                Name = lessonModel.Name,
                CourseId = lessonModel.CourseId,
                Description = lessonModel.Description,
                LessonUrl = lessonModel.LessonUrl,
                Image = lessonModel.Image,
            };

            _repository.CreateLesson(lesson);
        }

        public void UpdateLesson(LessonModel lessonModel)
        {
            Lesson lesson = new Lesson()
            {
                LessonId = lessonModel.LessonId,
                CourseId = lessonModel.CourseId,
                Name = lessonModel.Name,
                Description = lessonModel.Description,
                LessonUrl = lessonModel.LessonUrl,
                Image = lessonModel.Image,
            };

            _repository.UpdateLesson(lesson);

        }

        public void DeleteLesson(int Id)
        {
            _repository.DeleteLesson(Id);
        }
    }
}
