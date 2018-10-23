using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.DAL;
using MovieApp.Model;

namespace MovieApp.BLL
{
    public class OrderBLL
    {
        public List<Order> ListOrders()
        {
            var OrderDAL = new OrderDAL();
            List<Order> allOrders = OrderDAL.ListOrders();
            return allOrders;
        }

        public bool DeleteOrder(int id)
        {
            var orderDAL = new OrderDAL();
            return orderDAL.DeleteOrder(id);
        }

        public Order viewOrderDetails(int id)
        {
            var OrderDAL = new OrderDAL();
            return OrderDAL.viewOrderDetails(id);
        }

        public bool editOrder(int id, Order order)
        {
            var orderDAL = new OrderDAL();
            return orderDAL.editOrder(id, order);
        }
    }
}
