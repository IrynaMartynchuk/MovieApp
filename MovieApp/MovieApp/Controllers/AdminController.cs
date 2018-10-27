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
        private IAdminBLL _adminBLL;
        public AdminController()
        {
            _adminBLL = new AdminBLL();
        }
        public AdminController(IAdminBLL stub)
        {
            _adminBLL = stub;
        }
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
            var loggedIn = _adminBLL.login(Admin);

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
                return View(); 
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

        public ActionResult ListAdmins()
        {
            List<dbAdmins> allAdmins = _adminBLL.listAdmins();
            return View(allAdmins);
        }

        public ActionResult DeleteAdmin(int id)
        {
            dbAdmins admin = _adminBLL.viewDetails(id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult DeleteAdmin(int id, dbAdmins admin)
        {

            if (ModelState.IsValid)
            {
                bool deleteOK = _adminBLL.deleteAdmin(id);
                if (deleteOK)
                {
                    return RedirectToAction("ListAdmins");
                }
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            dbAdmins admin = _adminBLL.viewDetails(id);
            return View(admin);
        }

        public ActionResult EditAdmin(int id)
        {
            dbAdmins admin = _adminBLL.viewDetails(id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult EditAdmin(int id, dbAdmins admin)
        {
            if (ModelState.IsValid)
            {
                bool changeOK = _adminBLL.editAdmin(id, admin);
                if (changeOK)
                {
                    return RedirectToAction("ListAdmins");
                }
                else
                {
                    ViewBag.Message = "Some mistake occured";
                }
            }
            else
            {
                ViewBag.Message = "Some mistake occured";
            }
            return View();
        }

        public ActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                bool insertOK = _adminBLL.addAdmin(admin);
                if (insertOK)
                {
                    return RedirectToAction("ListAdmins");
                }
            }
            ViewBag.Message = "Some mistake occured or admin with such name already exists!";
            return View();
        }

    }
}