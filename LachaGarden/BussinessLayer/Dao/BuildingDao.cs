using DataAccessLayer.Models;

namespace BussinessLayer.Dao
{
    internal class BuildingDao
    {
        //-----------------------
        private lachagardenContext db = new lachagardenContext();

        private static BuildingDao instance = null;
        private static readonly object instanceLock = new object();

        private BuildingDao()
        {
        }

        public static BuildingDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BuildingDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<Building> getBuildingList()
        {
            var buildings = new List<Building>();
            List<Building> FList = new List<Building>();
            try
            {
                using var context = new lachagardenContext();
                buildings = context.Buildings.ToList();
                for (int i = 1; i <= buildings.Count; i++)
                {
                    FList.Add(buildings[i - 1]);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;
        }

        //-----------------------
        public Building GetBuildingByID(int BuildingID)
        {
            Building building = null;
            try
            {
                using var context = new lachagardenContext();
                building = context.Buildings.SingleOrDefault(p => p.Id == BuildingID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return building;
        }

        //-----------------------
        public void addNewBuilding(Building building)
        {
            try
            {
                Building buildings = GetBuildingByID(building.Id);
                if (buildings == null)
                {
                    using var context = new lachagardenContext();
                    context.Buildings.Add(building);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The building is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(Building building)
        {
            try
            {
                Building buildings = GetBuildingByID(building.Id);
                if (buildings != null)
                {
                    using var context = new lachagardenContext();
                    context.Buildings.Update(building);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The building does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Building> GetFilteredBuilding(String tag)
        {
            List<Building> filtered = new List<Building>();
            foreach (Building building in getBuildingList())
            {
                int add = 0;
                if (building.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(building);
            }
            return filtered;
        }
    }
}