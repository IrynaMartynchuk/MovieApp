using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.DAL;
using MovieApp.Model;

namespace MovieApp.BLL
{
    public class OrderBLL : BLL.IOrderBLL
    {

        private IOrderRepository _repository;

        public OrderBLL()
        {
            _repository = new OrderDAL();
        }

        public OrderBLL(IOrderRepository stub)
        {
            _repository = stub;
        }
        public List<Order> ListOrders()
        {
            List<Order> allOrders = _repository.ListOrders();
            return allOrders;
        }

        public bool DeleteOrder(int id)
        {
            return _repository.DeleteOrder(id);
        }

        public Order viewOrderDetails(int id)
        {
            return _repository.viewOrderDetails(id);
        }

        public bool editOrder(int id, Order order)
        {
            return _repository.editOrder(id, order);
        }

        public List<Order> getOrders(int id)
        {
            List<Order> allOrders = _repository.getOrders(id);
            return allOrders;
        }

        public List<Orderline> getOrderlines(int id)
        {
            List<Orderline> allOrders = _repository.getOrderlines(id);
            return allOrders;
        }
    }
}
