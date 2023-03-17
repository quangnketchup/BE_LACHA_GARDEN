using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Dao
{
    public class UserDao
    {
        //-----------------------
        private lachagardenContext db = new lachagardenContext();

        private static UserDao instance = null;
        private static readonly object instanceLock = new object();

        private UserDao()
        {
        }

        public static UserDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<User> getUserList()
        {
            List<User> FList = new List<User>();
            try
            {
                using var context = new lachagardenContext();
                var users = context.Users.Where(c => c.Status == 1).ToList();
                if (users.Any())
                {
                    FList.AddRange(users);
                }
                else
                {
                    FList = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;
        }

        //-----------------------
        public User GetUserByID(string UserID)
        {
            User user = null;
            try
            {
                using var context = new lachagardenContext();
                user = context.Users.SingleOrDefault(p => p.Id == UserID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        //-----------------------
        public void addNewUser(User user)
        {
            try
            {
                User users = GetUserByID(user.Id);
                if (users == null)
                {
                    using var context = new lachagardenContext();
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The User is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(User user)
        {
            try
            {
                User users = GetUserByID(user.Id);
                if (users != null)
                {
                    using var context = new lachagardenContext();
                    context.Users.Update(user);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The User does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public void Remove(string userId)
        {
            try
            {
                User users = GetUserByID(userId);
                if (users != null)
                {
                    using (lachagardenContext db = new lachagardenContext())
                    {
                        User gardenPack = db.Users.Where(d => d.Id == userId).First();
                        gardenPack.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The User does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<User> GetFilteredUser(String tag)
        {
            List<User> filtered = new List<User>();
            foreach (User user in getUserList())
            {
                int add = 0;
                if (user.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(user);
            }
            return filtered;
        }

        public User GetUser(string email)
        {
            User user = null;
            try
            {
                using var context = new lachagardenContext();
                user = context.Users.SingleOrDefault(a => a.Gmail.Equals(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
    }
}