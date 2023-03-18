using BussinessLayer.Dao;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Repository
{
    public class RequestRepository
    {
        public IEnumerable<Request> GetFiltered(string tag) => RequestDao.Instance.GetFilteredRequest(tag);

        public Request GetRequestByID(int requestID) => RequestDao.Instance.GetRequestByID(requestID);

        public IEnumerable<Request> GetRequests() => RequestDao.Instance.getRequestList();

        public void InsertRequest(Request request) => RequestDao.Instance.addNewRequest(request);

        public void RemoveRequest(int requestId) => RequestDao.Instance.Remove(requestId);

        public void UpdateRequest(Request request) => RequestDao.Instance.Update(request);
    }
}