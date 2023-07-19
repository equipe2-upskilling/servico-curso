using ServiceCourse.Domain.Authentication;
using ServiceCourse.Domain.Services;
using ServiceCourse.Web.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace ServiceCourse.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        CourseService service = new CourseService();
        CryptoHelper cryptoHelper = new CryptoHelper();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            var admin = service.GetLogin(login.Email, login.Password);
            var pass = cryptoHelper.Encrypt(login.Password, login.Salt);

            if (admin.Id > 0 && pass == login.Password)
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