using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.DAL;
using MovieApp.Model;

namespace MovieApp.BLL
{
    public class AdminBLL : BLL.IAdminBLL
    {
        private IAdminRepository _repository;

        public AdminBLL()
        {
            _repository = new AdminDAL();
        }

        public AdminBLL(IAdminRepository stub)
        {
            _repository = stub;
        }
        public dbAdmins login(Admin Admin)
        {
            var loggedIn = _repository.login(Admin);
            return loggedIn;
        }

        public List<dbAdmins> listAdmins()
        {
            List<dbAdmins> allAdmins = _repository.listAdmins();
            return allAdmins;
        }

        public bool deleteAdmin(int id)
        {
            return _repository.DeleteAdmin(id);
        }

        public dbAdmins viewDetails(int id)
        {
            return _repository.viewDetails(id);
        }

        public bool editAdmin(int id, dbAdmins admin)
        {
            return _repository.editAdmin(id, admin);
        }

        public bool addAdmin(Admin admin)
        {
            bool insertOK = _repository.addAdmin(admin);
            return insertOK;
        }
    }
}
