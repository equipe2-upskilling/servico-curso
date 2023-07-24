using ServiceCourse.Domain.Services;
using ServiceCourse.Web.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace ServiceCourse.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        LoginService service = new LoginService();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            var user = service.GetuserByEmail(login.Email, login.Password);
            var authenticate = service.Authenticate(login.Password, user.Password, user.Salt);

            if (authenticate)
            {
                FormsAuthentication.RedirectFromLoginPage(login.Email, createPersistentCookie: false);
                return RedirectToAction("Index", "Course");

            }
            else
            {
                ViewBag.ErrorMessage = "Credenciais inválidas. Tente novamente.";
                return View();

            }

        }
    }
}