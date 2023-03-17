using DataAccessLayer.Models;

namespace BussinessLayer.IRepository
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetRoles();

        Role GetRoleByID(int RoleID);

        IEnumerable<Role> GetFiltered(string tag);
    }
}