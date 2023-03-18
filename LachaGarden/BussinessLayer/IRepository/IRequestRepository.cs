using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.IRepository
{
    public interface IRequestRepository
    {
        IEnumerable<Request> GetRequests();

        Request GetRequestByID(int requestID);

        IEnumerable<Request> GetFiltered(string tag);

        void InsertRequest(Request request);

        void UpdateRequest(Request request);

        void RemoveRequest(int requestId);
    }
}