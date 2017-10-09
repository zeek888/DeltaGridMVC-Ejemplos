La clase Global(Global.asax) debe tener la siguiente estructura:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

[assembly: PreApplicationStartMethod(typeof(<espacio de nombres>.Global), "Register")]
namespace <espacio de nombres>
{
    public class Global : HttpApplication
    {
        public static void Register()
        {
            HttpApplication.RegisterModule(typeof(DeltaWebControlMVC.Helper.DeltaScriptModulo));
        }


        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            DeltaWebControlMVC.Configuracion.AplicacionDG.Configurar(o =>
            {
                o.Layout = "~/Views/Shared/LayoutDG.cshtml";
            });


        }
    }
}

Al instalar el paquete se intentará configurar de forma automática, favor de revisar que la configuración se halla aplicado.