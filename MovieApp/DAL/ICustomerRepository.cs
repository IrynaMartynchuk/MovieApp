using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Model;

namespace MovieApp.DAL
{
    public interface ICustomerRepository
    {
        bool addCustomer(Customer inCustomer);
        List<Customer> listCustomers();
        bool deleteCustomer(int id);
        bool editCustomer(int id, Customer customer);

    }
}
