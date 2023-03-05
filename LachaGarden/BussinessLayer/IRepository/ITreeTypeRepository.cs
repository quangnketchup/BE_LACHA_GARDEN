using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.IRepository
{
    public interface ITreeTypeRepository
    {
        IEnumerable<TreeType> GetTreeTypes();
        TreeType GetTreeTypeByID(int treeTypeID);
        IEnumerable<TreeType> GetFiltered(string tag);
        void InsertTreeType(TreeType treeType);
        void UpdateTreeType(TreeType treeType);
        void RemoveTreeType(int treeTypeId);
    }
}
