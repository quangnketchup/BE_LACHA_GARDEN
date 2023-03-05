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
    public class BuildingRepository : IBuildingRepository
    {
            public IEnumerable<Building> GetFiltered(string tag) => BuildingDao.Instance.GetFilteredBuilding(tag);

            public Building GetBuildingByID(int BuildingID) => BuildingDao.Instance.GetBuildingByID(BuildingID);

            public IEnumerable<Building> GetBuildings() => BuildingDao.Instance.getBuildingList();
        }
    
}
