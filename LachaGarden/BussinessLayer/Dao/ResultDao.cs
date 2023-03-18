using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Dao
{
    public class ResultDao
    {
        //-----------------------
        private lachagardenContext db = new lachagardenContext();

        private static ResultDao instance = null;
        private static readonly object instanceLock = new object();

        private ResultDao()
        {
        }

        public static ResultDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ResultDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<Result> getResultList()
        {
            var results = new List<Result>();
            List<Result> FList = new List<Result>();
            try
            {
                using var context = new lachagardenContext();
                results = context.Results.ToList();
                for (int i = 1; i <= results.Count; i++)
                {
                    if (results[i - 1].Status == 1) { FList.Add(results[i - 1]); }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;
        }

        //-----------------------
        public Result GetResultByID(int ResultID)
        {
            Result results = null;
            try
            {
                using var context = new lachagardenContext();
                results = context.Results.SingleOrDefault(p => p.Id == ResultID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return results;
        }

        //-----------------------
        public void addNewResult(Result result)
        {
            try
            {
                Result results = GetResultByID(result.Id);
                if (results == null)
                {
                    using var context = new lachagardenContext();
                    context.Results.Add(result);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Result is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(Result result)
        {
            try
            {
                Result results = GetResultByID(result.Id);
                if (results != null)
                {
                    using var context = new lachagardenContext();
                    context.Results.Update(result);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Result does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public void Remove(int ResultId)
        {
            try
            {
                Result results = GetResultByID(ResultId);
                if (results != null)
                {
                    using (lachagardenContext db = new lachagardenContext())
                    {
                        Result result = db.Results.Where(d => d.Id == ResultId).First();
                        result.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The Result does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Result> GetFilteredResult(String tag)
        {
            List<Result> filtered = new List<Result>();
            foreach (Result result in getResultList())
            {
                int add = 0;
                if (result.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(result);
            }
            return filtered;
        }
    }
}