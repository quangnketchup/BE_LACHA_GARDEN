using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
