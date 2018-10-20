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
            if (Session["admin"] != null)
            {
                return RedirectToAction("AdminIndex", "Admin", new { admin = Session["admin"].ToString() });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin Admin)
        {
            var db = new AdminBLL();
            var loggedIn = db.login(Admin);

            if (loggedIn != null)
            {
                ViewBag.message = "You are logged in";
                ViewBag.triedOnce = true;

                Session["admin"] = Admin.AdminID;
                return RedirectToAction("AdminIndex", "Admin", new { admin = Admin.AdminID });
            }
            else
            {
                ViewBag.triedOnce = true;
                return View(); //if failed - error message 
            }
        }

        public ActionResult Logout()
        {
            if (Session["admin"] != null)
            {
                Session["admin"] = null;
                return RedirectToAction("AdminLogin", "Admin");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin", new { admin = Session["admin"].ToString() });
            }

        }

    }
}