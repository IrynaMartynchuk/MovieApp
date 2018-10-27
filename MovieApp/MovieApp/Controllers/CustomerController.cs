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

        //TESTED
        public ActionResult RegisterCustomer()
        {
            return View();
        }
        //TESTED
        [HttpPost]
        public ActionResult RegisterCustomer(Customer inCustomer)
        {
            if (ModelState.IsValid)
            {
                //var db = new CustomerBLL();
                bool insertOK = _customerBLL.addCustomer(inCustomer);
                if (insertOK)
                {
                    return RedirectToAction("ListCustomers");
                }
            }
            ViewBag.Message = "Some mistake occured or user with such email already exists!";
            return View();
        }
        //TESTED
        public ActionResult ListCustomers()
        {
            List<Customer> allCustomers = _customerBLL.listCustomers();
            return View(allCustomers);
        }
        //TESTED
        public ActionResult ViewDetails(int id) {
            
            Customer customer = _customerBLL.viewDetails(id);
            return View(customer);
        }
        //TESTED
        public ActionResult DeleteCustomer(int id)
        {
        
            Customer customer = _customerBLL.viewDetails(id);
            //ViewData["test"] = "Delete1 OK";
            return View(customer);
        }
        //TESTED
        [HttpPost]
        public ActionResult DeleteCustomer(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool deleteOK = _customerBLL.deleteCustomer(id);
                if (deleteOK)
                {
                    //ViewData["test"] = "Delete2 OK";
                    return RedirectToAction("ListCustomers");
                }
                //ViewData["test"] = "Modal state NOT valid";
            }
            //ViewData["test"] = "Delete NOT OK";
            return View();
        } 

        //TESTED
        public ActionResult EditCustomer(int id) {

            //var db = new CustomerBLL();
            Customer customer = _customerBLL.viewDetails(id);
            //ViewData["test"] = "edit ok";
            return View(customer);
        }

        //TESTED
        [HttpPost]
        public ActionResult EditCustomer(int id, Customer inCustomer)
        {
            ViewData["test"] = "test";
            if (ModelState.IsValid)
            {
                //var db = new CustomerBLL();
                bool changeOK = _customerBLL.editCustomer(inCustomer.Id, inCustomer);
                if (changeOK)
                {
                    return RedirectToAction("ListCustomers");
                }
                else
                {
                    ViewData["test"] = "change is not ok";
                    return View();
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