using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Service.CourseGama.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //ConfigureAuth();

        }

        //private void ConfigureAuth()
        //{
        //    var cookieOptions = new CookieAuthenticationOptions
        //    {
        //        AuthenticationType = "ApplicationCookie",
        //        LoginPath = new PathString("/Account/Login"),
        //    };

        //    // Adicionar o middleware de autenticação de cookies
        //    appBuilder.UseCookieAuthentication(cookieOptions);

        //    // Configurar o middleware de autenticação JWT
        //    var openIdOptions = new OpenIdConnectAuthenticationOptions
        //    {
        //        ClientId = "SEU_CLIENT_ID",
        //        ClientSecret = "SEU_CLIENT_SECRET",
        //        Authority = "URL_DA_SUA_API",
        //        RedirectUri = "URL_DO_RETORNO_APÓS_LOGIN",
        //        ResponseType = OpenIdConnectResponseType.Code,
        //        Scope = "SEU_ESCOPE",
        //        SignInAsAuthenticationType = cookieOptions.AuthenticationType,
        //        TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidIssuer = "EMISSOR_DO_TOKEN",
        //            ValidateAudience = true,
        //            ValidAudience = "AUDIENCIA_DO_TOKEN",
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SUA_CHAVE_SECRETA")),
        //        },
        //    };

        //    appBuilder.UseOpenIdConnectAuthentication(openIdOptions);
        //}
    }
}