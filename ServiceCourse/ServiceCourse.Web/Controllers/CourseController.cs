using ServiceCourse.Domain.Models;
using ServiceCourse.Domain.Services;
using ServiceCourse.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ServiceCourse.Web.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        CourseService _courseService = new CourseService();
        TeacherService _teacherService = new TeacherService();

        public ActionResult Index()
        {
            var courses = _courseService.GetCourses();
            var coursesViewModel = new List<CourseViewModel>();

            foreach (var course in courses)
            {
                coursesViewModel.Add(new CourseViewModel
                {
                    CourseId = course.CourseId,
                    Name = course.Name,
                    Description = course.Description,
                    Duration = course.Duration,
                    CoverImg = course.CoverImg,
                    TeacherId = course.TeacherId,
                    Price = course.Price,
                    Status = (CourseViewModel.EnrollmentStatus)course.Status
                });
            }
            if (courses.Count == 0 || courses == null)
            {
                ViewBag.Message = "Não existem cursos cadastrados.";
            }
            return View(coursesViewModel);
        }

        public ActionResult Details(int id)
        {
            var course = _courseService.GetCourseById(id);

            var teacher = _teacherService.GetTeacherById(course.TeacherId);

            if (teacher != null)
                course.TeacherName = teacher.TeacherName;

            var courseViewModel = new CourseViewModel()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description,
                Duration = course.Duration,
                Price = course.Price,
                CoverImg = course.CoverImg,
                TeacherId = course.TeacherId,
                TeacherName = course.TeacherName,
                Status = (CourseViewModel.EnrollmentStatus)course.Status
            };

            return View(courseViewModel);
        }

        public ActionResult Create()
        {
            var teachers = _teacherService.GetTeachers();

            ViewBag.Teachers = new SelectList(teachers, "Id", "TeacherName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseViewModel courseViewModel)
        {
            try
            {
                CourseModel course = new CourseModel()
                {
                    Name = courseViewModel.Name,
                    Description = courseViewModel.Description,
                    Duration = courseViewModel.Duration,
                    TeacherId = courseViewModel.TeacherId,
                    CoverImg = courseViewModel.CoverImg,
                    Price = courseViewModel.Price,
                };

                _courseService.CreateCourse(course);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

        public ActionResult Edit(int id)
        {
            var course = _courseService.GetCourseById(id);
            var teachers = _teacherService.GetTeachers();

            var selectedTeacher = teachers.FirstOrDefault(p => p.Id == course.TeacherId);
            if (selectedTeacher != null)
            {
                teachers.Insert(0, selectedTeacher);
            }
            else
            {
                teachers.Insert(0, new TeacherModel { Id = 0, TeacherName = "Selecione um professor" });
            }

            ViewBag.Teachers = new SelectList(teachers.Distinct(), "Id", "TeacherName");

            var courseViewModel = new CourseViewModel()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description,
                Duration = course.Duration,
                TeacherId = course.TeacherId,
                CoverImg = course.CoverImg,
                Price = course.Price,
                Status = (CourseViewModel.EnrollmentStatus)course.Status
            };

            return View(courseViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CourseViewModel courseViewModel)
        {
            try
            {
                CourseModel course = new CourseModel()
                {
                    CourseId = courseViewModel.CourseId,
                    Name = courseViewModel.Name,
                    Description = courseViewModel.Description,
                    Duration = courseViewModel.Duration,
                    TeacherId = courseViewModel.TeacherId,
                    CoverImg = courseViewModel.CoverImg,
                    Price = courseViewModel.Price,
                    Status = (CourseModel.EnrollmentStatus)courseViewModel.Status
                };

                _courseService.UpdateCourse(course);

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
                _courseService.DeleteCourse(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }
    }
}
