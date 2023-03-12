using DataAccessLayer.Models;

namespace BussinessLayer.IRepository
{
    public interface IGardenPackageRepository
    {
        IEnumerable<GardenPackage> GetGardenPackages();

        GardenPackage GetGardenPackageByID(int gardenPackageID);

        IEnumerable<GardenPackage> GetFiltered(string tag);

        void InsertGardenPackage(GardenPackage gardenPackage);

        void UpdateGardenPackage(GardenPackage gardenPackage);

        void RemoveGardenPackage(int gardenPackageId);
    }
}