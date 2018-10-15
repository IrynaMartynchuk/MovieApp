using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.DAL;
using MovieApp.Model;

namespace MovieApp.BLL
{
    public class CartBLL
    {
        public void addOrderline(string id, int movieId)
        {
            var OrderDAL = new OrderDAL();
            OrderDAL.addOrderline(id, movieId);
        }

        public List<Movie> showCartItems(string id)
        {
            var OrderDAL = new OrderDAL();
            List<Movie> allItems = OrderDAL.showCartItems(id);
            return allItems;
        }

        public void deleteCartItem(int id)
        {
            var OrderDAL = new OrderDAL();
            OrderDAL.deleteCartItem(id);
        }

        public void changeConfirmationStatus()
        {
            var OrderDAL = new OrderDAL();
            OrderDAL.changeConfirmedToTrue();
        }

    }
}
