using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.Model;
using MovieApp.BLL;

namespace MovieApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListOrders()
        {
            var db = new OrderBLL(); //change to CustomerBLL
            List<Order> allOrders = db.ListOrders();
            return View(allOrders);
        }

        
        public ActionResult DeleteOrder(int id)
        {
            var db = new OrderBLL();
            Order order = db.viewOrderDetails(id);
            return View(order);
        }
        

        [HttpPost]
        public ActionResult DeleteOrder(int id, Order order)
        {
            if (ModelState.IsValid)
            {
                var db = new OrderBLL();
                bool deleteOK = db.DeleteOrder(id);
                if (deleteOK)
                {
                    return RedirectToAction("ListOrders");
                }
            }
            ViewBag.Message = "Some mistake occured";
            return View();
        }

        public ActionResult EditOrder(int id)
        {
            var db = new OrderBLL();
            Order order = db.viewOrderDetails(id);
            return View(order);
        }

        [HttpPost]
        public ActionResult EditOrder(int id, Order order)
        {
            if (ModelState.IsValid)
            {
                var db = new OrderBLL();
                bool changeOK = db.editOrder(id, order);
                if (changeOK)
                {
                    return RedirectToAction("ListOrders");
                }
                else
                {
                    ViewBag.Message = "Mistake occured";
                }
            }
            else
            {
                ViewBag.Message = "Mistake occured";
            }
            return View();
        }

        public ActionResult getOrders(int id)
        {
            var db = new OrderBLL();
            List<Order> allOrders = db.getOrders(id);
            return View(allOrders);
        }
    }
}