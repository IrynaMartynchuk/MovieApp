using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using MovieApp.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;

namespace MovieApp.DAL
{
    public class CustomerDAL : DAL.ICustomerRepository
    {
        //integration test
        public bool saveCustomer(Customer innKunde)
        {
            using (var db = new DBContext())
            {
                var existingCustomer = db.Customers.Where(a => a.Email == innKunde.Email).SingleOrDefault();
                if (existingCustomer == null)
                {
                    try
                    {
                        var newCustomer = new Customer();
                        newCustomer.Name = innKunde.Name;
                        newCustomer.Surname = innKunde.Surname;
                        newCustomer.Email = innKunde.Email;
                        newCustomer.Password = innKunde.Password;

                        db.Customers.Add(newCustomer);
                        db.SaveChanges();

                        return true;
                    }
                    catch (Exception e)
                    {
                        Error.logError("Customer:saveCustomer", e);
                        return false;
                    }
                }
                else
                    return false;

            }
        }


        public bool addCustomer(Customer inCustomer)
        {
            try
            {
                if (inCustomer.Name != null && inCustomer.Surname != null && inCustomer.Email != null && inCustomer.Password != null)
                {
                    var newCustomer = new Customer()
                    {
                        Name = inCustomer.Name,
                        Surname = inCustomer.Surname,
                        Email = inCustomer.Email,
                        Password = inCustomer.Password
                    };


                    using (var db = new DBContext())
                    {
                        db.Customers.Add(newCustomer);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Error.logError("Customer:addCustomer", e);
            }
            return false;
        }

        public List<Customer> listCustomers()
        {
            using (var db = new DBContext()) 
            {
                List<Customer> allCustomers = (from customer in db.Customers.AsEnumerable()
                                               select new Customer()
                                               {
                                                   Id = customer.Id,
                                                   Name = customer.Name,
                                                   Surname = customer.Surname,
                                                   Email = customer.Email
                                               }).ToList();
                return allCustomers;
            }
        }

        public Customer viewDetails(int id) {
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
        }



        public bool deleteCustomer(int id)
        {
            using (var db = new DBContext())
            {
                try
                {
                    Customer customer = db.Customers.Find(id);
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Error.logError("Customer:delete", e);
                    return false;
                }
            }
        }

        public bool editCustomer(int id, Customer customer)
        {
            var db = new DBContext();
            var result = db.Customers.Find(id);

            if (result != null)
            {
                result.Name = customer.Name;
                result.Surname = customer.Surname;
                result.Email = customer.Email;
                    try
                    {
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Error.logError("Customer:editCustomer", e);
                        return false;
                    }
                
            }
            return false;
        }

        public Customer login(Customer Customer)
        {
            using(var db = new DBContext())
            {
                var loggedIn = db.Customers.SingleOrDefault(c => c.Email == Customer.Email && c.Password == Customer.Password);
                var orders = db.Orders.SingleOrDefault(o => o.Confirmed == false);
                try
                {
                    loggedIn.Orders.Add(orders);
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    Error.logError("Customer:login", e);
                }
                return loggedIn;
            }
        }
    }
}