using BussinessLayer.Dao;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;

namespace BussinessLayer.Repository
{
    public class BuildingRepository : IBuildingRepository
    {
        public IEnumerable<Building> GetFiltered(string tag) => BuildingDao.Instance.GetFilteredBuilding(tag);

        public Building GetBuildingByID(int BuildingID) => BuildingDao.Instance.GetBuildingByID(BuildingID);

        public IEnumerable<Building> GetBuildings() => BuildingDao.Instance.getBuildingList();
    }
}