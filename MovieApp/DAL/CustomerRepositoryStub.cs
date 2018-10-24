using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Model;

namespace MovieApp.DAL
{
    public class CustomerRepositoryStub : DAL.ICustomerRepository
    {
        public bool addCustomer(Customer inCustomer)
        {
           if(inCustomer.Surname == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Customer> listCustomers()
        {
            var list_customers = new List<Customer>();
            var newCustomer = new Customer()
            {
                Id = 1,
                Name = "Maja",
                Surname = "Kiszka",
                Email = "kiszka.maja@gmail.com",
                Password = "12345678cd",
            };
            list_customers.Add(newCustomer);
            list_customers.Add(newCustomer);

            return list_customers;
        }

      /*  public Customer viewDetails(int id)
        {
            using (var db = new DBContext())
            {
                var customer = db.Customers.Find(id);

                if (customer == null)
                {
                    return null;
                }
                else
                {
                    var orders = (from order in db.Orders where order.Customer.Id == id select order).ToList();
                    var details = new Customer()
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        Surname = customer.Surname,
                        Email = customer.Email
                    };
                    return details;
                }
            }
        }*/ //noot sure

        public bool deleteCustomer(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool editCustomer(int id, Customer customer)
        {
            if(id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*public Customer login(Customer Customer)
        {
            using (var db = new DBContext())
            {
                var loggedIn = db.Customers.SingleOrDefault(c => c.Email == Customer.Email && c.Password == Customer.Password);
                var orders = db.Orders.SingleOrDefault(o => o.Confirmed == false);
                loggedIn.Orders.Add(orders);
                db.SaveChanges();
                return loggedIn;
            }
        }*/
        
    }

}

