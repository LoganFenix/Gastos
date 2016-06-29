using EmoticonPlatzi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmoticonPlatzi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            ViewBag.Welcomemessage = "Hola Mundo";
            ViewBag.ValorEntero = 1;
            return View();
        }

        public ActionResult IndexAlt()
        {

            var model = new Home();
            model.WelcomeMessage = "Hola Mundo";

            return View(model);
        }
    }
}