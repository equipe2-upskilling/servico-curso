using ServiceCourse.Domain.Models;
using ServiceCourse.Domain.Services;
using ServiceCourse.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ServiceCourse.Web.Controllers
{
    
    public class CourseController : Controller
    {
        CourseService service = new CourseService();

        public ActionResult Login()
        {
            return View();
        }
        // GET: Course
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

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Course/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [Authorize]
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

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Course/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(CourseViewModel courseViewModel)
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

                service.UpdateCourse(course);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/5
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
