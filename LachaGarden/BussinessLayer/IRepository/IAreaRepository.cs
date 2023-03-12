using DataAccessLayer.Models;

namespace BussinessLayer.IRepository
{
    public interface IAreaRepository
    {
        IEnumerable<Area> GetAreas();

        Area GetAreaByID(int AreaID);

        IEnumerable<Area> GetFiltered(string tag);
    }
}