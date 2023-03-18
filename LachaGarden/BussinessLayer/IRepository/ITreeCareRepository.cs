using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.IRepository
{
    public interface ITreeCareCareRepository
    {
        IEnumerable<TreeCare> GetTreeCares();

        TreeCare GetTreeCareByID(int treeCareID);

        IEnumerable<TreeCare> GetFiltered(string tag);

        void InsertTreeCare(TreeCare treeCare);

        void UpdateTreeCare(TreeCare treeCare);

        void RemoveTreeCare(int treeCareId);
    }
}