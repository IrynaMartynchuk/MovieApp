using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.BLL;
using MovieApp.Model;

namespace MovieApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult AdminIndex()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        
    }
}