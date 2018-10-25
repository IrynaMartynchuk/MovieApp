using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Model;

namespace MovieApp.DAL
{
    public class OrderRepositoryStub : DAL.IOrderRepository
    {
        public bool DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public bool editOrder(int id, Order order)
        {
            throw new NotImplementedException();
        }

        public List<Orderline> getOrderlines(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> getOrders(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> ListOrders()
        {
            var expected_result = new List<Order>();

            var order = new Order()
            {
                Id = 1,
                Confirmed = true,
                SessionId = "hgfvjegvfjegvf",
                Customer = new Customer()
                {
                    Id = 1,
                    Name = "Iryna",
                    Surname = "Martynchuk",
                    Email = "martynchuk20101988@gmail.com",
                    Password = "5503371h"
                }
            };

            expected_result.Add(order);
            expected_result.Add(order);
            expected_result.Add(order);
            return expected_result;
        }

        public Order viewOrderDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
