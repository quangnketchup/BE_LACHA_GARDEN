using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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