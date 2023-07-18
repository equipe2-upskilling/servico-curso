using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ServiceCourse.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                var identity = (System.Security.Claims.ClaimsIdentity)User.Identity;
                // Aqui, você pode acessar as informações do usuário autenticado, se necessário
                // identity.Name, identity.Claims, etc.
            }
        }

        protected void Application_BeginRequest()
        {
            // Manter o contexto OWIN atualizado a cada solicitação
            HttpContext.Current.Items["owin.Environment"] = new Dictionary<string, object>();
        }
    }
}
