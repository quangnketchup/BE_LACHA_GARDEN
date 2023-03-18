using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Dao
{
    public class RequestDao
    {
        //-----------------------
        private lachagardenContext db = new lachagardenContext();

        private static RequestDao instance = null;
        private static readonly object instanceLock = new object();

        private RequestDao()
        {
        }

        public static RequestDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RequestDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<Request> getRequestList()
        {
            var requests = new List<Request>();
            List<Request> FList = new List<Request>();
            try
            {
                using var context = new lachagardenContext();
                requests = context.Requests.ToList();
                for (int i = 1; i <= requests.Count; i++)
                {
                    if (requests[i - 1].Status == 1) { FList.Add(requests[i - 1]); }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;
        }

        //-----------------------
        public Request GetRequestByID(int RequestID)
        {
            Request requests = null;
            try
            {
                using var context = new lachagardenContext();
                requests = context.Requests.SingleOrDefault(p => p.Id == RequestID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return requests;
        }

        //-----------------------
        public void addNewRequest(Request request)
        {
            try
            {
                Request requests = GetRequestByID(request.Id);
                if (requests == null)
                {
                    using var context = new lachagardenContext();
                    context.Requests.Add(request);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Request is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(Request request)
        {
            try
            {
                Request requests = GetRequestByID(request.Id);
                if (requests != null)
                {
                    using var context = new lachagardenContext();
                    context.Requests.Update(request);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Request does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public void Remove(int RequestId)
        {
            try
            {
                Request requests = GetRequestByID(RequestId);
                if (requests != null)
                {
                    using (lachagardenContext db = new lachagardenContext())
                    {
                        Request request = db.Requests.Where(d => d.Id == RequestId).First();
                        request.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The Request does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Request> GetFilteredRequest(String tag)
        {
            List<Request> filtered = new List<Request>();
            foreach (Request request in getRequestList())
            {
                int add = 0;
                if (request.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(request);
            }
            return filtered;
        }
    }
}