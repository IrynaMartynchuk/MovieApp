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
        bool addCustomer(Customer inCustomer); 
        List<Customer> listCustomers(); 
        bool deleteCustomer(int id); 
        bool editCustomer(int id, Customer customer); 
        Customer viewDetails(int id); 
    }
}
