using DataAccessLayer.Models;

namespace BussinessLayer.Dao
{
    public class GardenPackageDao
    {
        //-----------------------
        private lachagardenContext db = new lachagardenContext();

        private static GardenPackageDao instance = null;
        private static readonly object instanceLock = new object();

        private GardenPackageDao()
        {
        }

        public static GardenPackageDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new GardenPackageDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<GardenPackage> getGardenPackageList()
        {
            var gardenpacks = new List<GardenPackage>();
            List<GardenPackage> FList = new List<GardenPackage>();
            try
            {
                using var context = new lachagardenContext();
                gardenpacks = context.GardenPackages.ToList();
                for (int i = 1; i <= gardenpacks.Count; i++)
                {
                    if (gardenpacks[i - 1].Status == 1) { FList.Add(gardenpacks[i - 1]); }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;
        }

        //-----------------------
        public GardenPackage GetGardenPackageByID(int GardenPackageID)
        {
            GardenPackage gardenPackage = null;
            try
            {
                using var context = new lachagardenContext();
                gardenPackage = context.GardenPackages.SingleOrDefault(p => p.Id == GardenPackageID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return gardenPackage;
        }

        //-----------------------
        public void addNewGardenPackage(GardenPackage gardenPackage)
        {
            try
            {
                GardenPackage gardenPacks = GetGardenPackageByID(gardenPackage.Id);
                if (gardenPacks == null)
                {
                    using var context = new lachagardenContext();
                    context.GardenPackages.Add(gardenPackage);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Garden packs is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(GardenPackage gardenPackage)
        {
            try
            {
                GardenPackage gardenPacks = GetGardenPackageByID(gardenPackage.Id);
                if (gardenPacks != null)
                {
                    using var context = new lachagardenContext();
                    context.GardenPackages.Update(gardenPackage);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Garden packs does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public void Remove(int gardenPackageId)
        {
            try
            {
                GardenPackage gardenPacks = GetGardenPackageByID(gardenPackageId);
                if (gardenPacks != null)
                {
                    using (lachagardenContext db = new lachagardenContext())
                    {
                        GardenPackage gardenPack = db.GardenPackages.Where(d => d.Id == gardenPackageId).First();
                        gardenPack.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The Garden pack does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<GardenPackage> GetFilteredGardenPackage(String tag)
        {
            List<GardenPackage> filtered = new List<GardenPackage>();
            foreach (GardenPackage gardenPackage in getGardenPackageList())
            {
                int add = 0;
                if (gardenPackage.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(gardenPackage);
            }
            return filtered;
        }
    }
}