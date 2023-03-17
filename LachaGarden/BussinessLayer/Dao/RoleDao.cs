using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Dao
{
    public class RoleDao
    {
        //-----------------------
        private lachagardenContext db = new lachagardenContext();

        private static RoleDao instance = null;
        private static readonly object instanceLock = new object();

        private RoleDao()
        {
        }

        public static RoleDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoleDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<Role> getRoleList()
        {
            var role = new List<Role>();
            List<Role> FList = new List<Role>();
            try
            {
                using var context = new lachagardenContext();
                role = context.Roles.ToList();
                for (int i = 1; i <= role.Count; i++)
                {
                    FList.Add(role[i - 1]);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;
        }

        //-----------------------
        public Role GetRoleByID(int RoleID)
        {
            Role role = null;
            try
            {
                using var context = new lachagardenContext();
                role = context.Roles.SingleOrDefault(p => p.RoleId == RoleID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return role;
        }

        //-----------------------
        public void addNewRole(Role role)
        {
            try
            {
                Role roles = GetRoleByID(role.RoleId);
                if (roles == null)
                {
                    using var context = new lachagardenContext();
                    context.Roles.Add(role);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Role is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(Role role)
        {
            try
            {
                Role roles = GetRoleByID(role.RoleId);
                if (roles != null)
                {
                    using var context = new lachagardenContext();
                    context.Roles.Update(role);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Role does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public List<Role> GetFilteredRole(String tag)
        {
            List<Role> filtered = new List<Role>();
            foreach (Role role in getRoleList())
            {
                int add = 0;
                if (role.RoleId.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(role);
            }
            return filtered;
        }
    }
}