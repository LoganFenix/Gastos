﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastosBootStrap.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home!
        public ActionResult Index()
        {
            int numero = new int();

            return View();
            
          
        }
    }
}