using BussinessLayer.Dao;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Repository
{
    public class RoleRepository : IRoleRepository
    {
        public IEnumerable<Role> GetFiltered(string tag) => RoleDao.Instance.GetFilteredRole(tag);

        public Role GetRoleByID(int RoleID) => RoleDao.Instance.GetRoleByID(RoleID);

        public IEnumerable<Role> GetRoles() => RoleDao.Instance.getRoleList();
    }
}