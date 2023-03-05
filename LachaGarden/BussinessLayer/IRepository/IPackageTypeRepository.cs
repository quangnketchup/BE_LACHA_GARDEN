using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
