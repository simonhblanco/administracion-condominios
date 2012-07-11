using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Condominios.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Sistema Administrativo de Condominios.";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
