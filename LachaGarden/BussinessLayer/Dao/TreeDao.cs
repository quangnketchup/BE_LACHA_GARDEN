using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Dao
{
    public class TreeDao
    {
        //-----------------------
        lachagardenContext db = new lachagardenContext();
        private static TreeDao instance = null;
        private static readonly object instanceLock = new object();
        private TreeDao() { }
        public static TreeDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TreeDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<Tree> getTreeList()
        {
            var trees = new List<Tree>();
            List<Tree> FList = new List<Tree>();
            try
            {
                using var context = new lachagardenContext();
                trees = context.Trees.ToList();
                for (int i = 1; i <= trees.Count; i++)
                {
                    if (trees[i - 1].Status == 1) { FList.Add(trees[i - 1]); }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;

        }

        //-----------------------
        public Tree GetTreeByID(int TreeID)
        {
            Tree trees = null;
            try
            {
                using var context = new lachagardenContext();
                trees = context.Trees.SingleOrDefault(p => p.Id == TreeID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return trees;
        }

        //-----------------------
        public void addNewTree(Tree tree)
        {
            try
            {
                Tree trees = GetTreeByID(tree.Id);
                if (trees == null)
                {
                    using var context = new lachagardenContext();
                    context.Trees.Add(tree);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Tree is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(Tree tree)
        {
            try
            {
                Tree trees = GetTreeByID(tree.Id);
                if (trees != null)
                {
                    using var context = new lachagardenContext();
                    context.Trees.Update(tree);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Tree does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public void Remove(int TreeId)
        {
            try
            {
                Tree trees = GetTreeByID(TreeId);
                if (trees != null)
                {
                    using (lachagardenContext db = new lachagardenContext())
                    {
                        Tree tree = db.Trees.Where(d => d.Id == TreeId).First();
                        tree.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The Tree does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Tree> GetFilteredTree(String tag)
        {
            List<Tree> filtered = new List<Tree>();
            foreach (Tree tree in getTreeList())
            {
                int add = 0;
                if (tree.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(tree);
            }
            return filtered;
        }
    }
}
