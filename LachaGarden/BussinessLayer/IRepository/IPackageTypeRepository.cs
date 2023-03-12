using DataAccessLayer.Models;

namespace BussinessLayer.IRepository
{
    public interface IPackageTypeRepository
    {
        IEnumerable<PackageType> GetPackageTypes();

        PackageType GetPackageTypeByID(int packageTypeID);

        IEnumerable<PackageType> GetFiltered(string tag);

        void InsertPackageType(PackageType PackageType);

        void UpdatePackageType(PackageType PackageType);

        void RemovePackageType(int packageTypeId);
    }
}