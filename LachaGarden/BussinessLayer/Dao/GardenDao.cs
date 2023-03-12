using DataAccessLayer.Models;

namespace BussinessLayer.Dao
{
    public class GardenDao
    {
        //-----------------------
        private lachagardenContext db = new lachagardenContext();

        private static GardenDao instance = null;
        private static readonly object instanceLock = new object();

        private GardenDao()
        {
        }

        public static GardenDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new GardenDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<Garden> getGardenList()
        {
            var gardens = new List<Garden>();
            List<Garden> FList = new List<Garden>();
            try
            {
                using var context = new lachagardenContext();
                gardens = context.Gardens.ToList();
                for (int i = 1; i <= gardens.Count; i++)
                {
                    if (gardens[i - 1].Status == 1 || gardens[i - 1].Status == 3 || gardens[i - 1].Status == 2) { FList.Add(gardens[i - 1]); }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;
        }

        //-----------------------
        public Garden GetGardenByID(int GardenID)
        {
            Garden garden = null;
            try
            {
                using var context = new lachagardenContext();
                garden = context.Gardens.SingleOrDefault(p => p.Id == GardenID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return garden;
        }

        //-----------------------
        public void addNewGarden(Garden garden)
        {
            try
            {
                Garden gardens = GetGardenByID(garden.Id);
                if (gardens == null)
                {
                    using var context = new lachagardenContext();
                    context.Gardens.Add(garden);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Garden is already exist.");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and display the error message
                string errorMessage = "An error occurred while saving the entity changes.";
                if (ex.InnerException != null)
                {
                    errorMessage += " See inner exception for details.";
                    errorMessage += " Inner exception message: " + ex.InnerException.Message;
                }
                throw new Exception(errorMessage, ex);
            }
        }

        //-----------------------
        public void Update(Garden garden)
        {
            try
            {
                Garden gardens = GetGardenByID(garden.Id);
                if (gardens != null)
                {
                    using var context = new lachagardenContext();
                    context.Gardens.Update(garden);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Garden does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public void Remove(int GardenId)
        {
            try
            {
                Garden gardens = GetGardenByID(GardenId);
                if (gardens != null)
                {
                    using (lachagardenContext db = new lachagardenContext())
                    {
                        Garden garden = db.Gardens.Where(d => d.Id == GardenId).First();
                        garden.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The Garden does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Garden> GetFilteredGarden(string tag)
        {
            List<Garden> filtered = new List<Garden>();
            foreach (Garden garden in getGardenList())
            {
                int add = 0;
                if (garden.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(garden);
            }
            return filtered;
        }
    }
}