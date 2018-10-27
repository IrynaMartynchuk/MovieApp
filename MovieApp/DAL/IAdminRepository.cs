using System.Collections.Generic;
using MovieApp.Model;

namespace MovieApp.DAL
{
    public interface IAdminRepository
    {
        bool addAdmin(Admin admin);
        bool editAdmin(int id, dbAdmins admin);
        List<dbAdmins> listAdmins();
        dbAdmins login(Admin Admin);
        dbAdmins viewDetails(int id);
        bool DeleteAdmin(int id);
    }
}