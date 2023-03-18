using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.IRepository
{
    public interface IResultRepository
    {
        IEnumerable<Result> GetResults();

        Result GetResultByID(int resultID);

        IEnumerable<Result> GetFiltered(string tag);

        void InsertResult(Result result);

        void UpdateResult(Result result);

        void RemoveResult(int resultId);
    }
}