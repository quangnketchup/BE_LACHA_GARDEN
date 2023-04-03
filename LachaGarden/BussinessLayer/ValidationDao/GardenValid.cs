using BussinessLayer.Dao;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationDao
{
    public class GardenValid
    {
        private GardenDao gardenDao;

        public GardenValid(GardenDao gardenDao)
        {
            this.gardenDao = gardenDao;
        }

        public GardenValid()
        {
        }

        public void checkIDRoom(int id)
        {
            Room room = RoomDao.Instance.GetRoomByID(id);
            if (room == null)
            {
                throw new Exception("Room not exist!");
            }
        }

        public void checkIDGardenPackage(int id)
        {
            var garden = gardenDao.GetGardenByID(id);
            int gardenPackageId = (int)garden.GardenPackageId;
            GardenPackage gardenPackage = GardenPackageDao.Instance.GetGardenPackageByID(gardenPackageId);
            if (gardenPackage != null) { }
            {
                throw new Exception("GardenPackage not exist!");
            }
        }
    }
}