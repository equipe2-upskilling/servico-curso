using ServiceCourse.Domain.Models;
using ServiceCourse.Domain.Services;
using ServiceCourse.Web.Models;
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
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    Duration = course.Duration,
                    Price = course.Price,
                    Status = (CourseViewModel.EnrollmentStatus)course.Status
                });
            }
            return View(coursesViewModel);
        }

        public ActionResult Details(int id)
        {
            var course = service.GetCourseById(id);

            var courseViewModel = new CourseViewModel()
            {
                Id = course.Id,
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
                CourseModel course = new CourseModel()
                {
                    Name = courseViewModel.Name,
                    Description = courseViewModel.Description,
                    Duration = courseViewModel.Duration,
                    Price = courseViewModel.Price,
                };

                service.CreateCourse(course);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var course = service.GetCourseById(id);

            var courseViewModel = new CourseViewModel()
            {
                Id = course.Id,
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
                    Id = courseViewModel.Id,
                    Name = courseViewModel.Name,
                    Description = courseViewModel.Description,
                    Duration = courseViewModel.Duration,
                    Price = courseViewModel.Price,
                    Status = (CourseModel.EnrollmentStatus)courseViewModel.Status
                };

                service.UpdateCourse(course);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                service.DeleteCourse(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
