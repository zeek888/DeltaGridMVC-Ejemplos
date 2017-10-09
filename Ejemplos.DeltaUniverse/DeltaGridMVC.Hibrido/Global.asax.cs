using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

[assembly: PreApplicationStartMethod(typeof(DeltaGridMVC.Hibrido.Global), "Register")]
namespace DeltaGridMVC.Hibrido
{
    public class Global : HttpApplication
    {
        public static void Register()
        {
            HttpApplication.RegisterModule(typeof(DeltaWebControlMVC.Helper.DeltaScriptModulo));
        }

        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            DeltaGridWebAPI.Servicios.DeltaGridAPIConfig.Configurar(o =>
                       {
                           o.SeguridadAPI = (contexto, tipoValidacion) => true;
                       });

            System.Web.Hosting.HostingEnvironment.RegisterVirtualPathProvider(new DeltaWebControlMVC.Helper.VistaProvider());
            DeltaWebControlMVC.Configuracion.AplicacionDG.Configurar(o =>
            {
                o.Layout = "~/Views/Shared/LayoutDG.cshtml";
            });
        }
    }
}
