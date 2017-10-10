using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeltaGridMVC.Hibrido.Controllers
{
    public class VistaController : Controller
    {
        // GET: Vista
        public ActionResult Ver(string id, string area = null)
        {
            if (area != null)
                return View($"~/Views/{area}/{id}.cshtml");
            else
                return View(id);
        }
    }
}