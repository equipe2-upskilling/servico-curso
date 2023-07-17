using Service.CourseGama.Domain.Services;
using Service.CourseGama.Web.Models;
using Servico.Curso.Gama.Domain.Model;
using System.Web.Mvc;

namespace Service.CourseGama.Web.Controllers
{
    public class CourseController : Controller
    {
        CourseService service = new CourseService();

        // GET: Curso
        public ActionResult Index()
        {
            return View();
        }

        // GET: Curso/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Curso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curso/Create
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

        // GET: Curso/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Curso/Edit/5
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

        // GET: Curso/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: Curso/Delete/5
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
