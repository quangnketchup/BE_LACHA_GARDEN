using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Dao
{
    internal class AreaDao
    {
        //-----------------------
        lachagardenContext db = new lachagardenContext();
        private static AreaDao instance = null;
        private static readonly object instanceLock = new object();
        private AreaDao() { }
        public static AreaDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AreaDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<Area> getAreaList()
        {
            var area = new List<Area>();
            List<Area> FList = new List<Area>();
            try
            {
                using var context = new lachagardenContext();
                area = context.Areas.ToList();
                for (int i = 1; i <= area.Count; i++)
                {
                    FList.Add(area[i - 1]);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;

        }

        //-----------------------
        public Area GetAreaByID(int AreaID)
        {
            Area area = null;
            try
            {
                using var context = new lachagardenContext();
                area = context.Areas.SingleOrDefault(p => p.Id == AreaID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return area;
        }

        //-----------------------
        public void addNewArea(Area area)
        {
            try
            {
                Area areas = GetAreaByID(area.Id);
                if (areas == null)
                {
                    using var context = new lachagardenContext();
                    context.Areas.Add(area);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The area is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(Area area)
        {
            try
            {
                Area areas = GetAreaByID(area.Id);
                if (areas != null)
                {
                    using var context = new lachagardenContext();
                    context.Areas.Update(area);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The area does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public List<Area> GetFilteredArea(String tag)
        {
            List<Area> filtered = new List<Area>();
            foreach (Area area in getAreaList())
            {
                int add = 0;
                if (area.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(area);
            }
            return filtered;
        }
    }
}