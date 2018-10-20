using MovieApp.BLL;
using MovieApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterCustomer(Customer inCustomer)
        {
            if (ModelState.IsValid)
            {
                var db = new HomeBLL();
                bool insertOK = db.saveCustomer(inCustomer);
                if (insertOK)
                {
                    return RedirectToAction("ListCustomers");
                }
            }
            ViewBag.Message = "Some mistake occured or user with such email already exists!";
            return View();
        }

        public ActionResult ListCustomers()
        {
            var db = new HomeBLL(); //change to CustomerBLL
            List<Customer> allCustomers = db.listCustomers();
            return View(allCustomers);
        }

        public ActionResult ViewDetails(int id) {
            var db = new HomeBLL(); //change to CustomerBLL
            Customer customer = db.viewDetails(id);
            return View(customer);
        }

        public ActionResult DeleteCustomer(int id)
        {
            var db = new HomeBLL();
            Customer customer = db.viewDetails(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                var db = new HomeBLL();
                bool deleteOK = db.deleteCustomer(id);
                if (deleteOK)
                {
                    return RedirectToAction("ListCustomers");
                }
            }
            ViewBag.Message = "Some mistake occured";
            return View();
        }

        public ActionResult EditCustomer(int id) {
            var db = new HomeBLL();
            Customer customer = db.viewDetails(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult EditCustomer(int id, Customer inCustomer)
        {
            if (ModelState.IsValid)
            {
                var db = new HomeBLL();
                bool changeOK = db.editCustomer(id, inCustomer);
                if (changeOK)
                {
                    return RedirectToAction("ListCustomers");
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
    }
}