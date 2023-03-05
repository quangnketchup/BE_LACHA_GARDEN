using BussinessLayer.Dao;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;

namespace BussinessLayer.Repository
{
    public class TreeRepository : ITreeRepository
    {
        public IEnumerable<Tree> GetFiltered(string tag) => TreeDao.Instance.GetFilteredTree(tag);

        public Tree GetTreeByID(int treeID) => TreeDao.Instance.GetTreeByID(treeID);

        public IEnumerable<Tree> GetTrees() => TreeDao.Instance.getTreeList();

        public void InsertTree(Tree tree) => TreeDao.Instance.addNewTree(tree);

        public void RemoveTree(int treeId) => TreeDao.Instance.Remove(treeId);

        public void UpdateTree(Tree tree) => TreeDao.Instance.Update(tree);
    }
}
