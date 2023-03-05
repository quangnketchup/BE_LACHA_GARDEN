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
    public class PackageTypeRepository : IPackageTypeRepository
    {
        public IEnumerable<PackageType> GetFiltered(string tag) => PackageTypeDao.Instance.GetFilteredPackageType(tag);

        public PackageType GetPackageTypeByID(int packageTypeID) => PackageTypeDao.Instance.GetPackageTypeByID(packageTypeID);

        public IEnumerable<PackageType> GetPackageTypes() => PackageTypeDao.Instance.getPackageTypeList();

        public void InsertPackageType(PackageType packageType) => PackageTypeDao.Instance.addNewPackageType(packageType);

        public void RemovePackageType(int packageTypeId) => PackageTypeDao.Instance.Remove(packageTypeId);

        public void UpdatePackageType(PackageType packageType) => PackageTypeDao.Instance.Update(packageType);
    }
}
