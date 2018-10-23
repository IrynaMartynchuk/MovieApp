using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Model;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MovieApp.DAL
{
    public class AdminDAL
    {
        public Admin login(Admin Admin)
        {
            using (var db = new DBContext())
            {
                var loggedIn = db.Admins.SingleOrDefault(c => c.Adminuser == Admin.Adminuser && c.PasswordAdmin == Admin.PasswordAdmin);
                db.SaveChanges();
                return loggedIn;
            }
        }
    }
}
