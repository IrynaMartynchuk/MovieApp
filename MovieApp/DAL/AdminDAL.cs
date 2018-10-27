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
        public dbAdmins login(Admin Admin)
        {
            using (var db = new DBContext())
            {
                byte[] password = makeHash(Admin.PasswordAdmin);
                var loggedIn = db.Admins.SingleOrDefault(c => c.adminUser == Admin.Adminuser && c.passwordAdmin == password);
                db.SaveChanges();
                return loggedIn;
            }
        }

        public List<dbAdmins> listAdmins()
        {
            using (var db = new DBContext())
            {
                List<dbAdmins> allAdmins = (from admin in db.Admins.AsEnumerable()
                                               select new dbAdmins()
                                               {
                                                   adminID = admin.adminID,
                                                   adminUser = admin.adminUser,
                                                   passwordAdmin = admin.passwordAdmin
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
                    dbAdmins admin = db.Admins.First(a => a.adminID == id);
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

        public dbAdmins viewDetails(int id)
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
                    var details = new dbAdmins()
                    {
                        adminID = admin.adminID,
                        adminUser = admin.adminUser,
                        passwordAdmin = admin.passwordAdmin
                    };
                    return details;
                }
            }
        }

        public bool editAdmin(int id, dbAdmins admin)
        {
            var db = new DBContext();
            var result = db.Admins.Find(id);

            if (result != null)
            {
                result.adminUser = admin.adminUser;
                result.passwordAdmin = admin.passwordAdmin;
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
            
            using (var db = new DBContext())
            {
                try
                {
                    var newAdmin = new dbAdmins();
                    byte[] password = makeHash(admin.PasswordAdmin);
                    newAdmin.passwordAdmin = password;
                    newAdmin.adminUser = admin.Adminuser;
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

        private static byte[] makeHash(string password)
        {
            byte[] inData, outData;
            var algorithm = System.Security.Cryptography.SHA256.Create();
            inData = Encoding.ASCII.GetBytes(password);
            outData = algorithm.ComputeHash(inData);
            return outData;
        }
    }
}
