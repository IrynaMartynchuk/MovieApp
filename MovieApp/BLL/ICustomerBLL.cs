using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Model;

namespace MovieApp.BLL
{
    public interface ICustomerBLL
    {
        bool addCustomer(Customer inCustomer); //done
        List<Customer> listCustomers(); //done
        bool deleteCustomer(int id); //done
        bool editCustomer(int id, Customer customer); //done
        Customer viewDetails(int id); //done
    }
}
