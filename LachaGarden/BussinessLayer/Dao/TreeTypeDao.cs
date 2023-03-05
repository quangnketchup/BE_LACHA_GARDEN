using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Dao
{
    public class TreeTypeDao
    {
        //-----------------------
        lachagardenContext db = new lachagardenContext();
        private static TreeTypeDao instance = null;
        private static readonly object instanceLock = new object();
        private TreeTypeDao() { }
        public static TreeTypeDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TreeTypeDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<TreeType> getTreeTypeList()
        {
            var treeTypes = new List<TreeType>();
            List<TreeType> FList = new List<TreeType>();
            try
            {
                using var context = new lachagardenContext();
                treeTypes = context.TreeTypes.ToList();
                for (int i = 1; i <= treeTypes.Count; i++)
                {
                    if (treeTypes[i - 1].Status == 1) { FList.Add(treeTypes[i - 1]); }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;

        }

        //-----------------------
        public TreeType GetTreeTypeByID(int TreeTypeID)
        {
            TreeType treeTypes = null;
            try
            {
                using var context = new lachagardenContext();
                treeTypes = context.TreeTypes.SingleOrDefault(p => p.Id == TreeTypeID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return treeTypes;
        }

        //-----------------------
        public void addNewTreeType(TreeType treeType)
        {
            try
            {
                TreeType treeTypes = GetTreeTypeByID(treeType.Id);
                if (treeTypes == null)
                {
                    using var context = new lachagardenContext();
                    context.TreeTypes.Add(treeType);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The TreeType is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(TreeType treeType)
        {
            try
            {
                TreeType treeTypes = GetTreeTypeByID(treeType.Id);
                if (treeTypes != null)
                {
                    using var context = new lachagardenContext();
                    context.TreeTypes.Update(treeType);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The TreeType does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public void Remove(int TreeTypeId)
        {
            try
            {
                TreeType treeTypes = GetTreeTypeByID(TreeTypeId);
                if (treeTypes != null)
                {
                    using (lachagardenContext db = new lachagardenContext())
                    {
                        TreeType treeType = db.TreeTypes.Where(d => d.Id == TreeTypeId).First();
                        treeType.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The TreeType does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TreeType> GetFilteredTreeType(String tag)
        {
            List<TreeType> filtered = new List<TreeType>();
            foreach (TreeType treeType in getTreeTypeList())
            {
                int add = 0;
                if (treeType.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(treeType);
            }
            return filtered;
        }
    }
}
