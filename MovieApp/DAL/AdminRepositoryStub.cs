using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Model;

namespace MovieApp.DAL
{
    public class AdminRepositoryStub : DAL.IAdminRepository
    {
        public bool addAdmin(Admin admin)
        {
            if (admin.Adminuser == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool editAdmin(int id, Admin admin)
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

        public List<Admin> listAdmins()
        {
            var expected_result = new List<Admin>();

            var admin = new Admin()
            {
                AdminID = 1,
                Adminuser = "Iryna",
                PasswordAdmin = "password"
            };

            expected_result.Add(admin);
            expected_result.Add(admin);
            expected_result.Add(admin);
            return expected_result;
        }

        public Admin login(Admin Admin)
        {
            if (Admin.AdminID == 0)
            {
                return null;
            }
            else
            {
                var admin = new Admin()
                {
                    AdminID = 1,
                    Adminuser = "ira",
                    PasswordAdmin = "hello"
                };
                return admin;
            }
        }

        public Admin viewDetails(int id)
        {
            var admin = new Admin()
            {
                AdminID = 1,
                Adminuser = "Iryna",
                PasswordAdmin = "password"
            };
            if (id == 0)
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
}
