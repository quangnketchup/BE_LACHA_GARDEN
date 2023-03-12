using DataAccessLayer.Models;

namespace BussinessLayer.IRepository
{
    public interface ITreeRepository
    {
        IEnumerable<Tree> GetTrees();

        Tree GetTreeByID(int treeID);

        IEnumerable<Tree> GetFiltered(string tag);

        void InsertTree(Tree tree);

        void UpdateTree(Tree tree);

        void RemoveTree(int treeId);
    }
}