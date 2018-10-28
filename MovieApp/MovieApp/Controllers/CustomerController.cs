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
                
                bool insertOK = _customerBLL.addCustomer(inCustomer);
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
            
            Customer customer = _customerBLL.viewDetails(id);
            return View(customer);
        }
        
        public ActionResult DeleteCustomer(int id)
        {
        
            Customer customer = _customerBLL.viewDetails(id);
            return View(customer);
        }
        
        [HttpPost]
        public ActionResult DeleteCustomer(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool deleteOK = _customerBLL.deleteCustomer(id);
                if (deleteOK)
                {
                    return RedirectToAction("ListCustomers");
                }
            }
            
            return View();
        } 

        
        public ActionResult EditCustomer(int id) {
            
            Customer customer = _customerBLL.viewDetails(id);
            return View(customer);
        }

        
        [HttpPost]
        public ActionResult EditCustomer(int id, Customer inCustomer)
        {
            ViewData["test"] = "test";
            if (ModelState.IsValid)
            {
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