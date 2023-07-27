using ServiceCourse.Domain.Models;
using ServiceCourse.Domain.Services;
using ServiceCourse.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ServiceCourse.Web.Controllers
{
    [Authorize]
    public class LessonController : Controller
    {
        LessonService service = new LessonService();

        public ActionResult Index(int id)
        {
            ViewBag.CourseId = id;

            var lessons = service.GetLessonsByCourseId(id);
            var lessonsViewModel = new List<LessonViewModel>();

            foreach (var lesson in lessons)
            {
                lessonsViewModel.Add(new LessonViewModel
                {
                    LessonId = lesson.LessonId,
                    CourseId = lesson.CourseId,
                    Name = lesson.Name,
                    Description = lesson.Description,
                    LessonUrl = lesson.LessonUrl,
                    Image = lesson.Image,
                });
            }
            if (lessons.Count == 0 || lessons == null)
            {
                ViewBag.Message = "Não existem lições cadastradas.";
            }
            return View(lessonsViewModel);
        }

        public ActionResult Details(int id)
        {
            var lesson = service.GetLessonById(id);

            var lessonViewModel = new LessonViewModel()
            {
                LessonId = lesson.LessonId,
                CourseId = lesson.CourseId,
                Name = lesson.Name,
                Description = lesson.Description,
                LessonUrl = lesson.LessonUrl,
                Image = lesson.Image,
            };

            return View(lessonViewModel);
        }

        public ActionResult Create(int id)
        {
            ViewBag.CourseId = id;

            return View();
        }

        [HttpPost]
        public ActionResult Create(LessonViewModel lessonViewModel)
        {
            try
            {
                LessonModel lesson = new LessonModel()
                {
                    Name = lessonViewModel.Name,
                    CourseId = lessonViewModel.CourseId,
                    Description = lessonViewModel.Description,
                    LessonUrl = lessonViewModel.LessonUrl,
                    Image = lessonViewModel.Image,
                };

                service.CreateLesson(lesson);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

        public ActionResult Edit(int id)
        {
            var lesson = service.GetLessonById(id);

            var lessonViewModel = new LessonViewModel()
            {
                LessonId = lesson.LessonId,
                CourseId = lesson.CourseId,
                Name = lesson.Name,
                Description = lesson.Description,
                LessonUrl = lesson.LessonUrl,
                Image = lesson.Image,
            };

            ViewBag.CourseId = lessonViewModel.CourseId;

            return View(lessonViewModel);
        }

        [HttpPost]
        public ActionResult Edit(LessonViewModel lessonViewModel)
        {
            try
            {
                LessonModel lesson = new LessonModel()
                {
                    LessonId = lessonViewModel.LessonId,
                    CourseId = lessonViewModel.CourseId,
                    Name = lessonViewModel.Name,
                    Description = lessonViewModel.Description,
                    LessonUrl = lessonViewModel.LessonUrl,
                    Image = lessonViewModel.Image,
                };

                service.UpdateLesson(lesson);

                return Json(new { success = true });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message });

            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                service.DeleteLesson(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }
    }
}
