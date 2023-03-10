using BussinessLayer.Dao;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Repository
{
    public class GardenRepository : IGardenRepository
    {
        public IEnumerable<Garden> GetFiltered(string tag) => GardenDao.Instance.GetFilteredGarden(tag);

        public Garden GetGardenByID(int GardenID) => GardenDao.Instance.GetGardenByID(GardenID);

        public IEnumerable<Garden> GetGardens() => GardenDao.Instance.getGardenList();

        public void InsertGarden(Garden garden) => GardenDao.Instance.addNewGarden(garden);

        public void RemoveGarden(int gardenId) => GardenDao.Instance.Remove(gardenId);

        public void UpdateGarden(Garden garden) => GardenDao.Instance.Update(garden);
    }
}
