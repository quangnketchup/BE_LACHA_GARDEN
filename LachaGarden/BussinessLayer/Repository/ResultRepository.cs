using BussinessLayer.Dao;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Repository
{
    public class ResultRepository
    {
        public IEnumerable<Result> GetFiltered(string tag) => ResultDao.Instance.GetFilteredResult(tag);

        public Result GetResultByID(int resultID) => ResultDao.Instance.GetResultByID(resultID);

        public IEnumerable<Result> GetResults() => ResultDao.Instance.getResultList();

        public void InsertResult(Result result) => ResultDao.Instance.addNewResult(result);

        public void RemoveResult(int resultId) => ResultDao.Instance.Remove(resultId);

        public void UpdateResult(Result result) => ResultDao.Instance.Update(result);
    }
}