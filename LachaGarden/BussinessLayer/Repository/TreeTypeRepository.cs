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
    public class TreeTypeRepository : ITreeTypeRepository
    {
        public IEnumerable<TreeType> GetFiltered(string tag) => TreeTypeDao.Instance.GetFilteredTreeType(tag);

        public TreeType GetTreeTypeByID(int treeTypeID) => TreeTypeDao.Instance.GetTreeTypeByID(treeTypeID);

        public IEnumerable<TreeType> GetTreeTypes() => TreeTypeDao.Instance.getTreeTypeList();

        public void InsertTreeType(TreeType treeType) => TreeTypeDao.Instance.addNewTreeType(treeType);

        public void RemoveTreeType(int treeTypeId) => TreeTypeDao.Instance.Remove(treeTypeId);

        public void UpdateTreeType(TreeType treeType) => TreeTypeDao.Instance.Update(treeType);
    }
}
