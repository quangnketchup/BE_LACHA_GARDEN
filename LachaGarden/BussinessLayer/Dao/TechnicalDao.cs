using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Dao
{
    public class TechnicalDao
    {
        /*
        //-----------------------
        lachagardenContext db = new lachagardenContext();
        private static TechnicalDao instance = null;
        private static readonly object instanceLock = new object();
        private TechnicalDao() { }
        public static TechnicalDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TechnicalDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<Technical> getTechnicalList()
        {
            var gardenpacks = new List<Technical>();
            List<Technical> FList = new List<Technical>();
            try
            {
                using var context = new lachagardenContext();
                gardenpacks = context.Technicals.ToList();
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
        public Technical GetTechnicalByID(int TechnicalID)
        {
            Technical technical = null;
            try
            {
                using var context = new lachagardenContext();
                technical = context.Technicals.SingleOrDefault(p => p.Id == TechnicalID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return technical;
        }

        //-----------------------
        public void addNewTechnical(Technical technical)
        {
            try
            {
                Technical technicals = GetTechnicalByID(technical.Id);
                if (technicals == null)
                {
                    using var context = new lachagardenContext();
                    context.Technicals.Add(technical);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The technical packs is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(Technical technical)
        {
            try
            {
                Technical technicals = GetTechnicalByID(technical.Id);
                if (technicals != null)
                {
                    using var context = new lachagardenContext();
                    context.Technicals.Update(technical);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The technical does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public void Remove(int technicalId)
        {
            try
            {
                Technical technicals = GetTechnicalByID(technicalId);
                if (technicals != null)
                {
                    using (lachagardenContext db = new lachagardenContext())
                    {
                        Technical technical = db.Technicals.Where(d => d.Id == technicalId).First();
                        technical.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The technical does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Technical> GetFilteredTechnical(String tag)
        {
            List<Technical> filtered = new List<Technical>();
            foreach (Technical technical in getTechnicalList())
            {
                int add = 0;
                if (technical.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(technical);
            }
            return filtered;
        }
        */
    }
}
