using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeltaGridMVC.Hibrido.Controllers
{
    public class ListaController : Controller
    {
        [HttpGet]
        public ActionResult Vista(string id)
        {
            return View(id);
        }
    }
}