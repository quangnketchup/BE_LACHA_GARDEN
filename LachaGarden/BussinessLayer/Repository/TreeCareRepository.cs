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
    public class TreeCareRepository : ITreeCareRepository
    {
        public IEnumerable<TreeCare> GetFiltered(string tag) => TreeCareDao.Instance.GetFilteredTreeCare(tag);

        public TreeCare GetTreeCareByID(int treeCareID) => TreeCareDao.Instance.GetTreeCareByID(treeCareID);

        public IEnumerable<TreeCare> GetTreeCares() => TreeCareDao.Instance.getTreeCareList();

        public void InsertTreeCare(TreeCare treeCare) => TreeCareDao.Instance.addNewTreeCare(treeCare);

        public void RemoveTreeCare(int treeCareId) => TreeCareDao.Instance.Remove(treeCareId);

        public void UpdateTreeCare(TreeCare treeCare) => TreeCareDao.Instance.Update(treeCare);
    }
}