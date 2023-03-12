using DataAccessLayer.Models;

namespace BussinessLayer.Dao
{
    public class PackageTypeDao
    {
        //-----------------------
        private lachagardenContext db = new lachagardenContext();

        private static PackageTypeDao instance = null;
        private static readonly object instanceLock = new object();

        private PackageTypeDao()
        {
        }

        public static PackageTypeDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PackageTypeDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<PackageType> getPackageTypeList()
        {
            var packTypes = new List<PackageType>();
            List<PackageType> FList = new List<PackageType>();
            try
            {
                using var context = new lachagardenContext();
                packTypes = context.PackageTypes.ToList();
                for (int i = 1; i <= packTypes.Count; i++)
                {
                    if (packTypes[i - 1].Status == 1) { FList.Add(packTypes[i - 1]); }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;
        }

        //-----------------------
        public PackageType GetPackageTypeByID(int PackageTypeID)
        {
            PackageType packType = null;
            try
            {
                using var context = new lachagardenContext();
                packType = context.PackageTypes.SingleOrDefault(p => p.Id == PackageTypeID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return packType;
        }

        //-----------------------
        public void addNewPackageType(PackageType packType)
        {
            try
            {
                PackageType packTypes = GetPackageTypeByID(packType.Id);
                if (packTypes == null)
                {
                    using var context = new lachagardenContext();
                    context.PackageTypes.Add(packType);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The package Type is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(PackageType packType)
        {
            try
            {
                PackageType packTypes = GetPackageTypeByID(packType.Id);
                if (packTypes != null)
                {
                    using var context = new lachagardenContext();
                    context.PackageTypes.Update(packType);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The packs type does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public void Remove(int packageTypeId)
        {
            try
            {
                PackageType packageTypes = GetPackageTypeByID(packageTypeId);
                if (packageTypes != null)
                {
                    using (lachagardenContext db = new lachagardenContext())
                    {
                        PackageType packageType = db.PackageTypes.Where(d => d.Id == packageTypeId).First();
                        packageType.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The package type does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<PackageType> GetFilteredPackageType(String tag)
        {
            List<PackageType> filtered = new List<PackageType>();
            foreach (PackageType packageType in getPackageTypeList())
            {
                int add = 0;
                if (packageType.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(packageType);
            }
            return filtered;
        }
    }
}