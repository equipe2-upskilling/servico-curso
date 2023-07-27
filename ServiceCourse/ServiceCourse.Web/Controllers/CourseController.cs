using ServiceCourse.Domain.Models;
using ServiceCourse.Domain.Services;
using ServiceCourse.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ServiceCourse.Web.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        CourseService service = new CourseService();

        public ActionResult Index()
        {
            var courses = service.GetCourses();
            var coursesViewModel = new List<CourseViewModel>();

            foreach (var course in courses)
            {
                coursesViewModel.Add(new CourseViewModel
                {
                    CourseId = course.CourseId,
                    Name = course.Name,
                    Description = course.Description,
                    Duration = course.Duration,
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
            var course = service.GetCourseById(id);

            var courseViewModel = new CourseViewModel()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description,
                Duration = course.Duration,
                Price = course.Price,
                Status = (CourseViewModel.EnrollmentStatus)course.Status
            };

            return View(courseViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseViewModel courseViewModel)
        {
            try
            {
                //to do
                //var teachers = service.GetTeachers();
                CourseModel course = new CourseModel()
                {
                    Name = courseViewModel.Name,
                    Description = courseViewModel.Description,
                    Duration = courseViewModel.Duration,
                    Price = courseViewModel.Price,
                };

                service.CreateCourse(course);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

        public ActionResult Edit(int id)
        {
            var course = service.GetCourseById(id);

            var courseViewModel = new CourseViewModel()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description,
                Duration = course.Duration,
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
                    Price = courseViewModel.Price,
                    Status = (CourseModel.EnrollmentStatus)courseViewModel.Status
                };

                service.UpdateCourse(course);

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
                service.DeleteCourse(id);
                return Json(new { success = true });
            }
            catch(Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }
    }
}
