using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.BLL;
using MovieApp.Model;

namespace MovieApp.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public void addToCart(int MovieId)
        {
            var db = new CartBLL();
            if (Session["Cart"] != null)
            {
                db.addOrderline(this.Session.SessionID, MovieId);
            }
        }

        public ActionResult Cart()
        {
            var db = new CartBLL();
            List<Movie> allItems = db.showCartItems(this.Session.SessionID);
            return View(allItems);
        }

        public void Delete(int id)
        {
            var db = new CartBLL();
            db.deleteCartItem(id);
        }

        public string Confirmation()
        {
            if (Session["customer"] == null)
            {
                var message = "In order to procceed you need to log in!";
                return message;
            }
            else
            {
                var ok = "You will receive confirmation email with receipt!";
                var db = new CartBLL();
                db.changeConfirmationStatus();
                return ok;
            }



        }


        /*public void changeConfirmationStatus()
        {
            if (Session["customer"] != null)
            {
                var db = new DBOrder();
                db.changeConfirmedToTrue();
            }
        }*/
    }
}