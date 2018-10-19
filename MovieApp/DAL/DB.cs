using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MovieApp.Model;


namespace MovieApp.DAL
{

    public class Customers
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }

    public class Admins
    {
        public int adminID { get; set; }
        public byte [] passwordAdmin { get; set; }
    }

    public class DBContext : DbContext
    {
        public DBContext() : base("name = WebApplication")
        // constructor for DBContext
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderline> Orderlines { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}