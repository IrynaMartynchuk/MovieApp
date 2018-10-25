using System.Collections.Generic;
using MovieApp.Model;

namespace MovieApp.DAL
{
    public interface IOrderRepository
    {
        bool DeleteOrder(int id);//done
        bool editOrder(int id, Order order);//done
        List<Orderline> getOrderlines(int id);
        List<Order> getOrders(int id);
        List<Order> ListOrders();//done
        Order viewOrderDetails(int id);//done
    }
}