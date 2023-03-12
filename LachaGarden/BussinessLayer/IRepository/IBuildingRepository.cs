using DataAccessLayer.Models;

namespace BussinessLayer.IRepository
{
    public interface IBuildingRepository
    {
        IEnumerable<Building> GetBuildings();

        Building GetBuildingByID(int buildingID);

        IEnumerable<Building> GetFiltered(string tag);
    }
}