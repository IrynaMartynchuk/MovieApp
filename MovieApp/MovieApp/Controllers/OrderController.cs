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

        private IOrderBLL _orderBLL;
        public OrderController()
        {
            _orderBLL = new OrderBLL();
        }
        public OrderController(IOrderBLL stub)
        {
            _orderBLL = stub;
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListOrders()
        {
            List<Order> allOrders = _orderBLL.ListOrders();
            return View(allOrders);
        }

        public ActionResult ViewDetails(int id)
        {
            Order order = _orderBLL.viewOrderDetails(id);
            return View(order);
        }


        public ActionResult DeleteOrder(int id)
        {
            Order order = _orderBLL.viewOrderDetails(id);
            return View(order);
        }
        

        [HttpPost]
        public ActionResult DeleteOrder(int id, Order order)
        {
            if (ModelState.IsValid)
            {
                bool deleteOK = _orderBLL.DeleteOrder(id);
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
            Order order = _orderBLL.viewOrderDetails(id);
            return View(order);
        }

        [HttpPost]
        public ActionResult EditOrder(int id, Order order)
        {
            if (ModelState.IsValid)
            {
                bool changeOK = _orderBLL.editOrder(id, order);
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
            List<Order> allOrders = _orderBLL.getOrders(id);
            return View(allOrders);
        }

        public ActionResult getOrderlines(int id)
        {
            List<Orderline> allOrders = _orderBLL.getOrderlines(id);
            return View(allOrders);
        }
    }
}