using BussinessLayer.Dao;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;

namespace BussinessLayer.Repository
{
    public class GardenPackageRepository : IGardenPackageRepository
    {
        public IEnumerable<GardenPackage> GetFiltered(string tag) => GardenPackageDao.Instance.GetFilteredGardenPackage(tag);

        public GardenPackage GetGardenPackageByID(int gardenPackageID) => GardenPackageDao.Instance.GetGardenPackageByID(gardenPackageID);

        public IEnumerable<GardenPackage> GetGardenPackages() => GardenPackageDao.Instance.getGardenPackageList();

        public void InsertGardenPackage(GardenPackage gardenPackage) => GardenPackageDao.Instance.addNewGardenPackage(gardenPackage);

        public void RemoveGardenPackage(int gardenPackageId) => GardenPackageDao.Instance.Remove(gardenPackageId);

        public void UpdateGardenPackage(GardenPackage gardenPackage) => GardenPackageDao.Instance.Update(gardenPackage);
    }
}