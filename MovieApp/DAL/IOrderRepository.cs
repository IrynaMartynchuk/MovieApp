﻿using System.Collections.Generic;
using MovieApp.Model;

namespace MovieApp.DAL
{
    public interface IOrderRepository
    {
        bool DeleteOrder(int id);
        bool editOrder(int id, Order order);
        List<Orderline> getOrderlines(int id);
        List<Order> getOrders(int id);
        List<Order> ListOrders();
        Order viewOrderDetails(int id);
    }
}