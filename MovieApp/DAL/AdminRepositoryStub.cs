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

        public bool DeleteAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public bool editAdmin(int id, dbAdmins admin)
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

        public List<dbAdmins> listAdmins()
        {
            var expected_result = new List<dbAdmins>();
            byte ten = 10;
            var admin = new dbAdmins()
            {
                adminID = 1,
                adminUser = "Iryna",
                passwordAdmin = { }
            };

            expected_result.Add(admin);
            expected_result.Add(admin);
            expected_result.Add(admin);
            return expected_result;
        }

        public dbAdmins login(Admin Admin)
        {
            if (Admin.AdminID == 0)
            {
                return null;
            }
            else
            {
                var admin = new dbAdmins()
                {
                    adminID = 1,
                    adminUser = "ira",
                    passwordAdmin = { }
                };
                return admin;
            }
        }

        public dbAdmins viewDetails(int id)
        {
            var admin = new dbAdmins()
            {
                adminID = 1,
                adminUser = "Iryna",
                passwordAdmin = { }
            };
            if (id == 0)
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
}
