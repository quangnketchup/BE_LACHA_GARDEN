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
    internal class TechnicalRepository : ITechnicalRepository
    {
        public IEnumerable<Technical> GetFiltered(string tag) => TechnicalDao.Instance.GetFilteredTechnical(tag);

        public Technical GetTechnicalByID(int TechnicalID) => TechnicalDao.Instance.GetTechnicalByID(TechnicalID);

        public IEnumerable<Technical> GetTechnicals() => TechnicalDao.Instance.getTechnicalList();

        public void InsertTechnical(Technical technical) => TechnicalDao.Instance.addNewTechnical(technical);

        public void RemoveTechnical(int TechnicalId) => TechnicalDao.Instance.Remove(TechnicalId);

        public void UpdateTechnical(Technical technical) => TechnicalDao.Instance.Update(technical);
    }
}
