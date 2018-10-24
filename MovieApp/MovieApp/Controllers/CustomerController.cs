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
        private ICustomerBLL _customerBLL;
        public CustomerController()
        {
            _customerBLL = new CustomerBLL();
        }
        public CustomerController(ICustomerBLL stub)
        {
            _customerBLL = stub;
        }
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
                var db = new CustomerBLL();
                bool insertOK = db.addCustomer(inCustomer);
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
            List<Customer> allCustomers = _customerBLL.listCustomers();
            return View(allCustomers);
        }

        public ActionResult ViewDetails(int id) {
            var db = new CustomerBLL(); //change to CustomerBLL
            Customer customer = db.viewDetails(id);
            return View(customer);
        }



        public ActionResult DeleteCustomer(int id)
        {
            var db = new CustomerBLL();
            Customer customer = db.viewDetails(id);
            ViewData["test"] = "Delete1 OK";
            return View(customer);
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                var db = new CustomerBLL();
                bool deleteOK = _customerBLL.deleteCustomer(id);
                if (deleteOK)
                {
                    ViewData["test"] = "Delete2 OK";
                    return RedirectToAction("ListCustomers");
                }
                ViewData["test"] = "Modal state NOT valid";
            }
            ViewData["test"] = "Delete NOT OK";
            return View();
        } 

        /*

        public ActionResult DeleteCustomer(int id)
        {
            var db = new CustomerBLL();
            Customer customer = db.viewDetails(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                var db = new CustomerBLL();
                bool deleteOK = db.deleteCustomer(id);
                if (deleteOK)
                {
                    return RedirectToAction("ListCustomers");
                }
            }
            ViewBag.Message = "Some mistake occured";
            return View();
        } */


        public ActionResult EditCustomer(int id) {
            var db = new CustomerBLL();
            Customer customer = db.viewDetails(id);
            ViewData["test"] = "edit ok";
            return View(customer);
        }

        [HttpPost]
        public ActionResult EditCustomer(Customer inCustomer)
        {
            ViewData["test"] = "test";
            if (ModelState.IsValid)
            {
                var db = new CustomerBLL();
                bool changeOK = db.editCustomer(inCustomer.Id, inCustomer);
                if (changeOK)
                {
                    return RedirectToAction("ListCustomers");
                }
                else
                {
                    ViewData["test"] = "change is not ok";
                }
            }
            else
            {
                ViewData["test"] = "state is not valid";
            }
            return View();
        }
    }
}