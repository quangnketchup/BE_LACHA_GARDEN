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
    public class AreaRepository : IAreaRepository
    {
        public IEnumerable<Area> GetFiltered(string tag) => AreaDao.Instance.GetFilteredArea(tag);

        public Area GetAreaByID(int AreaID) => AreaDao.Instance.GetAreaByID(AreaID);

        public IEnumerable<Area> GetAreas() => AreaDao.Instance.getAreaList();
    }
}
