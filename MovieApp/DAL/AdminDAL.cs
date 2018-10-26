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
    public class AdminDAL : DAL.IAdminRepository
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

        public List<Admin> listAdmins()
        {
            using (var db = new DBContext())
            {
                List<Admin> allAdmins = (from admin in db.Admins.AsEnumerable()
                                               select new Admin()
                                               {
                                                   AdminID = admin.AdminID,
                                                   Adminuser = admin.Adminuser,
                                                   PasswordAdmin = admin.PasswordAdmin
                                               }).ToList();
                return allAdmins;
            }
        }

        public bool DeleteAdmin(int id)
        {
            using (var db = new DBContext())
            {
                try
                {
                    Admin admin = db.Admins.Find(id);
                    db.Admins.Remove(admin);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public Admin viewDetails(int id)
        {
            using (var db = new DBContext())
            {
                var admin = db.Admins.Find(id);

                if (admin == null)
                {
                    return null;
                }
                else
                {
                    var details = new Admin()
                    {
                        AdminID = admin.AdminID,
                        Adminuser = admin.Adminuser,
                        PasswordAdmin = admin.PasswordAdmin
                    };
                    return details;
                }
            }
        }

        public bool editAdmin(int id, Admin admin)
        {
            var db = new DBContext();
            var result = db.Admins.Find(id);

            if (result != null)
            {
                result.Adminuser = admin.Adminuser;
                result.PasswordAdmin = admin.PasswordAdmin;
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        public bool addAdmin(Admin admin)
        {
            var newAdmin = new Admin()
            {
                Adminuser = admin.Adminuser,
                PasswordAdmin = admin.PasswordAdmin
            };

            using (var db = new DBContext())
            {
                try
                {
                    db.Admins.Add(newAdmin);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
