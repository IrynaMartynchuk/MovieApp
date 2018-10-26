using System.Collections.Generic;
using MovieApp.Model;

namespace MovieApp.DAL
{
    public interface IAdminRepository
    {
        bool addAdmin(Admin admin);
        bool editAdmin(int id, Admin admin);
        List<Admin> listAdmins();
        Admin login(Admin Admin);
        Admin viewDetails(int id);
    }
}