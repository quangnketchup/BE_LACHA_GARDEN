using DataAccessLayer.Models;

namespace BussinessLayer.IRepository
{
    public interface IGardenRepository
    {
        IEnumerable<Garden> GetGardens();

        Garden GetGardenByID(int GardenID);

        IEnumerable<Garden> GetFilteredGarden(string tag);

        void InsertGarden(Garden garden);

        void UpdateGarden(Garden garden);

        void RemoveGarden(int gardenId);
    }
}