using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Dao
{
    public class TreeCareDao
    {
        //-----------------------
        private lachagardenContext db = new lachagardenContext();

        private static TreeCareDao instance = null;
        private static readonly object instanceLock = new object();

        private TreeCareDao()
        {
        }

        public static TreeCareDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TreeCareDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<TreeCare> getTreeCareList()
        {
            var treeCares = new List<TreeCare>();
            List<TreeCare> FList = new List<TreeCare>();
            try
            {
                using var context = new lachagardenContext();
                treeCares = context.TreeCares.ToList();
                for (int i = 1; i <= treeCares.Count; i++)
                {
                    if (treeCares[i - 1].Status == 1) { FList.Add(treeCares[i - 1]); }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;
        }

        //-----------------------
        public TreeCare GetTreeCareByID(int TreeCareID)
        {
            TreeCare treeCares = null;
            try
            {
                using var context = new lachagardenContext();
                treeCares = context.TreeCares.SingleOrDefault(p => p.Id == TreeCareID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return treeCares;
        }

        //-----------------------
        public void addNewTreeCare(TreeCare treeCare)
        {
            try
            {
                TreeCare treeCares = GetTreeCareByID(treeCare.Id);
                if (treeCares == null)
                {
                    using var context = new lachagardenContext();
                    context.TreeCares.Add(treeCare);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The TreeCare is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(TreeCare treeCare)
        {
            try
            {
                TreeCare treeCares = GetTreeCareByID(treeCare.Id);
                if (treeCares != null)
                {
                    using var context = new lachagardenContext();
                    context.TreeCares.Update(treeCare);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The TreeCare does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public void Remove(int TreeCareId)
        {
            try
            {
                TreeCare treeCares = GetTreeCareByID(TreeCareId);
                if (treeCares != null)
                {
                    using (lachagardenContext db = new lachagardenContext())
                    {
                        TreeCare treeCare = db.TreeCares.Where(d => d.Id == TreeCareId).First();
                        treeCare.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The TreeCare does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TreeCare> GetFilteredTreeCare(String tag)
        {
            List<TreeCare> filtered = new List<TreeCare>();
            foreach (TreeCare treeCare in getTreeCareList())
            {
                int add = 0;
                if (treeCare.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(treeCare);
            }
            return filtered;
        }
    }
}